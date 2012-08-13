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
        private static readonly Dictionary<Type, MulticastDelegate> ConversionTargets =
            new Dictionary<Type, MulticastDelegate>
                {
                    { typeof(Byte), DefaultConversionFunctions.Byte },
                    { typeof(SByte), DefaultConversionFunctions.SByte },
                    { typeof(Int16), DefaultConversionFunctions.Int16 },
                    { typeof(Int32), DefaultConversionFunctions.Int32 },
                    { typeof(Int64), DefaultConversionFunctions.Int64 },
                    { typeof(UInt16), DefaultConversionFunctions.UInt16 },
                    { typeof(UInt32), DefaultConversionFunctions.UInt32 },
                    { typeof(UInt64), DefaultConversionFunctions.UInt64 },
                    { typeof(Single), DefaultConversionFunctions.Single },
                    { typeof(Double), DefaultConversionFunctions.Double },
                    { typeof(Boolean), DefaultConversionFunctions.Boolean },
                    { typeof(Char), DefaultConversionFunctions.Char },
                    { typeof(Decimal), DefaultConversionFunctions.Decimal },
                    { typeof(String), DefaultConversionFunctions.String },
                    { typeof(DateTime), DefaultConversionFunctions.DateTime },
                    { typeof(Byte?), DefaultConversionFunctions.NullableByte },
                    { typeof(SByte?), DefaultConversionFunctions.NullableSByte },
                    { typeof(Int16?), DefaultConversionFunctions.NullableInt16 },
                    { typeof(Int32?), DefaultConversionFunctions.NullableInt32 },
                    { typeof(Int64?), DefaultConversionFunctions.NullableInt64 },
                    { typeof(UInt16?), DefaultConversionFunctions.NullableUInt16 },
                    { typeof(UInt32?), DefaultConversionFunctions.NullableUInt32 },
                    { typeof(UInt64?), DefaultConversionFunctions.NullableUInt64 },
                    { typeof(Single?), DefaultConversionFunctions.NullableSingle },
                    { typeof(Double?), DefaultConversionFunctions.NullableDouble },
                    { typeof(Boolean?), DefaultConversionFunctions.NullableBoolean },
                    { typeof(Char?), DefaultConversionFunctions.NullableChar },
                    { typeof(Decimal?), DefaultConversionFunctions.NullableDecimal },
                    { typeof(DateTime?), DefaultConversionFunctions.NullableDateTime },
                };

        public static void AddConversionMap<T>(Func<String, IFormatProvider, T> conversionBehaviour)
        {
            if (!ConversionTargets.ContainsKey(typeof(T)))
            {
                ConversionTargets.Add(typeof(T), conversionBehaviour);
            }
            else
            {
                throw new ApplicationException("A conversion map for this type has already been registered.");
            }
        }

        public static void RemoveConversionMap(Type theType)
        {
            if (ConversionTargets.ContainsKey(theType))
            {
                ConversionTargets.Remove(theType);
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
                source.Select(element => DoMap<T>(element.Value, formatProvider));

            return result;
        }

        private static IEnumerable<T> TryConvertTo<T>(this IEnumerable<XElement> source, IFormatProvider formatProvider)
        {
            IEnumerable<T> result = source.Select(
                element =>
                    {
                        try
                        {
                            return DoMap<T>(element.Value, formatProvider);
                        }
                        catch
                        {
                            return default(T);
                        }
                    });

            return result;
        }

        private static TResult DoMap<TResult>(string inputValue, IFormatProvider formatProvider = null)
        {
            if (formatProvider == null) formatProvider = System.Globalization.CultureInfo.InvariantCulture;

            Func<string, IFormatProvider, TResult> mapper =
                (Func<string, IFormatProvider, TResult>)ConversionTargets[typeof(TResult)];
            TResult result = mapper(inputValue, formatProvider);
            return result;
        }
    }

    public enum ErrorBehaviour
    {
        ErrorsThrowExceptions,

        ErrorsReturnAsDefaultValues
    }
}
