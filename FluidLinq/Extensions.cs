/*
 * Copyright 2012 Christian Giacomi http://www.christiangiacomi.com
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FluidLinq
{


    /// <summary>
    /// Extension methods for the XElement class
    /// </summary>
    public static class Extensions
    {
        private static readonly Dictionary<Type, Func<String, IFormatProvider, Object>> ConversionTargets =
            new Dictionary<Type, Func<String, IFormatProvider, Object>>
                {
                    { typeof(Byte), (str, formatProvider) => Convert.ToByte(str, formatProvider) },
                    { typeof(SByte), (str, formatProvider) => Convert.ToSByte(str, formatProvider) },
                    { typeof(Int16), (str, formatProvider) => Convert.ToInt16(str, formatProvider) },
                    { typeof(Int32), (str, formatProvider) => Convert.ToInt32(str, formatProvider) },
                    { typeof(Int64), (str, formatProvider) => Convert.ToInt64(str, formatProvider) },
                    { typeof(UInt16), (str, formatProvider) => Convert.ToUInt16(str, formatProvider) },
                    { typeof(UInt32), (str, formatProvider) => Convert.ToUInt32(str, formatProvider) },
                    { typeof(UInt64), (str, formatProvider) => Convert.ToUInt64(str, formatProvider) },
                    { typeof(Single), (str, formatProvider) => Convert.ToSingle(str, formatProvider) },
                    { typeof(Double), (str, formatProvider) => Convert.ToDouble(str, formatProvider) },
                    { typeof(Boolean), (str, formatProvider) => Convert.ToBoolean(str, formatProvider) },
                    { typeof(Char), (str, formatProvider) => Convert.ToChar(str, formatProvider) },
                    { typeof(Decimal), (str, formatProvider) => Convert.ToDecimal(str, formatProvider) },
                    { typeof(String), (str, formatProvider) => str },
                    { typeof(DateTime), (str, formatProvider) => Convert.ToDateTime(str, formatProvider) },
                };

        public static void AddConversionMap<T>(Func<String, IFormatProvider, Object> conversionBehaviour)
        {
            if (!ConversionTargets.ContainsKey(typeof(T)))
            {
                ConversionTargets.Add(typeof(T), conversionBehaviour);
            }
            else
            {
                throw new ApplicationException("This conversion behaviour is already registered.");
            }
        }

        public static void RemoveConversionMap<T>()
        {
            if (ConversionTargets.ContainsKey(typeof(T)))
            {
                ConversionTargets.Remove(typeof(T));
            }
        }

        public static XDocument ToXDocument(this XmlDocument doc)
        {
            XDocument result;

            if (doc == null)
            {
                result = new XDocument();
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                doc.Save(stream);
                stream.Position = 0;
                result = XDocument.Load(stream);
            }

            return result;
        }

        public static IEnumerable<T> ConvertTo<T>(
            this IEnumerable<XElement> source,
            ErrorBehaviour errorBehaviour = ErrorBehaviour.ErrorsReturnAsDefaultValues,
            IFormatProvider formatProvider = null)
        {
            if (!ConversionTargets.ContainsKey(typeof(T))) throw new ApplicationException("This type conversion is not registered.");

            if (formatProvider == null) formatProvider = CultureInfo.InvariantCulture;

            switch (errorBehaviour)
            {

                case ErrorBehaviour.ErrorsReturnAsDefaultValues:
                    return source.TryConvertTo<T>(formatProvider);
                default:
                    return source.ConvertTo<T>(formatProvider);
            }
        }

        private static IEnumerable<T> ConvertTo<T>(this IEnumerable<XElement> source, IFormatProvider formatProvider)
        {
            IEnumerable<T> result =
                source.Select(element => (T)ConversionTargets[typeof(T)](element.Value, formatProvider));

            return result;
        }

        private static IEnumerable<T> TryConvertTo<T>(this IEnumerable<XElement> source, IFormatProvider formatProvider)
        {
            IEnumerable<T> result = source.Select(
                element =>
                {
                    try
                    {
                        return (T)ConversionTargets[typeof(T)](element.Value, formatProvider);
                    }
                    catch
                    {
                        return default(T);
                    }
                });

            return result;
        }
    }

    public enum ErrorBehaviour
    {
        ErrorsThrowExceptions,

        ErrorsReturnAsDefaultValues
    }
}
