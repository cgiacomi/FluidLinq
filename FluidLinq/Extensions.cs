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

namespace FluidLinq
{
    /// <summary>
    /// Extension methods for the XElement class
    /// </summary>
    public static class Extensions
    {
        private static Dictionary<Type, Func<string, object>> ConversionTargets = new Dictionary<Type, Func<string, object>>()
                                                                        {
                                                                            {typeof(int), str => System.Convert.ToInt32(str)},
                                                                            {typeof(long), str => Convert.ToInt64(str)},
                                                                            {typeof(float), str => float.Parse(str)},
                                                                            {typeof(bool), str => bool.Parse(str)},
                                                                            {typeof(string), str => str},
                                                                            {typeof(DateTime), str => DateTime.Parse(str)},
                                                                        };
        /// <summary>
        /// Gets the outer XML from the XElement
        /// </summary>
        /// <param name="element">the element</param>
        /// <returns>the Outer XML</returns>
        public static string OuterXml(this XElement element)
        {
            var xReader = element.CreateReader();
            xReader.MoveToContent();
            return xReader.ReadOuterXml();
        }

        /// <summary>
        /// Gets the Inner XML of an XElement
        /// </summary>
        /// <param name="element">the element</param>
        /// <returns>the inner XML</returns>
        public static string InnerXml(this XElement element)
        {
            var xReader = element.CreateReader();
            xReader.MoveToContent();
            return xReader.ReadInnerXml();
        }

        /// <summary>
        /// Allows a safe way to retrieve attribute values from an element
        /// </summary>
        /// <param name="element">A reference to the element object</param>
        /// <param name="attributeName">The name of the attribute</param>
        /// <returns>The attribute content or null</returns>
        public static T AttributeValueOrDefault<T>(this XElement element, string attributeName)
        {
            XAttribute attr = null;

            if (element != null)
                attr = element.Attribute(attributeName);

            return (attr == null) ? default(T) : (T)ConversionTargets[typeof(T)](attr.Value);
        }

        /// <summary>
        /// Allows a safe way to retrieve the value of an attribute for a child element in the current element.
        /// </summary>
        /// <typeparam name="T">the type for the conversion table</typeparam>
        /// <param name="childElement">the name of the child element</param>
        /// <param name="attributeName">the name of the attribute whose value you want</param>
        /// <returns>the converted attribute value or default(T)</returns>
        public static T AttributeValueForElementOrDefault<T>(this XElement parentElement,
                                                                    string childElement,
                                                                    string attributeName)
        {
            if (parentElement != null)
            {
                XElement child = parentElement.Element(childElement);

                XAttribute attr = null;
                if (child != null)
                {
                    attr = child.Attribute(attributeName);
                    return (attr == null) ? default(T) : (T)ConversionTargets[typeof(T)](attr.Value);
                }
            }

            return default(T);
        }


        /// <summary>
        /// Allows a safe way to retrieve the value of a nested element for a child element in the current element.
        /// </summary>
        /// <typeparam name="T">the type for the conversion table</typeparam>
        public static T ElementValueForElementOrDefault<T>(this XElement rootElement,
                                                                string parentElementName,
                                                                string childElementName)
        {
            if (rootElement != null)
            {
                XElement parentElement = rootElement.Element(parentElementName);
                if (parentElement != null)
                {
                    XElement childElement = parentElement.Element(childElementName);
                    if (childElement != null)
                        return (T)ConversionTargets[typeof(T)](childElement.Value);
                }
            }

            return default(T);
        }

        /// <summary>
        /// Allows a safe way to retrieve element data
        /// </summary>
        /// <param name="element">A reference to the element object</param>
        /// <returns>Element content or an empty string</returns>
        public static T ElementValueOrDefault<T>(this XElement element, string value)
        {
            if (element != null)
            {
                XElement child = element.Element(value);

                if (child != null)
                    return (T)ConversionTargets[typeof(T)](child.Value);
            }

            return default(T);
        }

        /// <summary>
        /// Converts an XmlNode to an XDocument for LINQ queries
        /// </summary>
        public static XDocument GetXDocument(this XmlNode node)
        {
            if (node == null)
                throw new InvokeMethodFromNullObjectException("Cannot call this extension method on a null object.");

            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                node.WriteTo(xmlWriter);
            return xDoc;
        }

        /// <summary>
        /// Converts an XmlNode to an XElement for LINQ queries
        /// </summary>
        public static XElement GetXElement(this XmlNode node)
        {
            if (node == null)
                throw new InvokeMethodFromNullObjectException("Cannot call this extension method on a null object.");

            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                node.WriteTo(xmlWriter);
            return xDoc.Root;
        }

        /// <summary>
        /// Converts an XElement to an XmlNode
        /// </summary>
        public static XmlNode GetXmlNode(this XElement element)
        {
            if (element == null)
                throw new InvokeMethodFromNullObjectException("Cannot call this extension method on a null object.");

            using (XmlReader xmlReader = element.CreateReader())
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);
                return xmlDoc;
            }
        }
    }
}
