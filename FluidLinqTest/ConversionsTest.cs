using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Xml.Linq;

using FluidLinq;

namespace FluidLinqTest
{
    [TestClass]
    public class ConversionsTest
    {
        private XmlDocument doc;
        private string xmlDoc = @"<conversion>
                                    <byte>255</byte>
                                    <sbyte>127</sbyte>
                                    <int16>32767</int16>
                                    <int32>2147483647</int32>
                                    <int64>9223372036854775807</int64>
                                    <uint16>65535</uint16>
                                    <uint32>4294967295</uint32>
                                    <uint64>18446744073709551615</uint64>
                                    <bool>true</bool>
                                    <char>c</char>
                                    <decimal>25162.1378</decimal>
                                    <string>Christian Giacomi</string>
                                    <datetime>01/22/1984</datetime>
                                  </conversion>";

        [TestInitialize]
        public void Setup()
        {
            doc = new XmlDocument();
            doc.LoadXml(xmlDoc);
        }

        [TestMethod]
        public void TestConversion_valid_Byte_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Byte result = xelem.ElementValueOrDefault<Byte>("byte");
            Assert.AreEqual(Byte.MaxValue, result);
        }

        [TestMethod]
        public void TestConversion_non_valid_Byte_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Byte result = xelem.ElementValueOrDefault<Byte>("nonvalid");
            Assert.AreEqual(default(Byte), result);
        }

        [TestMethod]
        public void TestConversion_valid_SByte_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            SByte result = xelem.ElementValueOrDefault<SByte>("sbyte");
            Assert.AreEqual(SByte.MaxValue, result);
        }

        [TestMethod]
        public void TestConversion_non_valid_SByte_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            SByte result = xelem.ElementValueOrDefault<SByte>("nonvalid");
            Assert.AreEqual(default(SByte), result);
        }

        [TestMethod]
        public void TestConversion_valid_Int16_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Int16 result = xelem.ElementValueOrDefault<Int16>("int16");
            Assert.AreEqual(Int16.MaxValue, result);
        }

        [TestMethod]
        public void TestConversion_non_valid_Int16_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Int16 result = xelem.ElementValueOrDefault<Int16>("nonvalid");
            Assert.AreEqual(default(Int16), result);
        }

        [TestMethod]
        public void TestConversion_valid_Int32_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Int32 result = xelem.ElementValueOrDefault<Int32>("int32");
            Assert.AreEqual(Int32.MaxValue, result);
        }

        [TestMethod]
        public void TestConversion_non_valid_Int32_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Int32 result = xelem.ElementValueOrDefault<Int32>("nonvalid");
            Assert.AreEqual(default(Int32), result);
        }

        [TestMethod]
        public void TestConversion_valid_Int64_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Int64 result = xelem.ElementValueOrDefault<Int64>("int64");
            Assert.AreEqual(Int64.MaxValue, result);
        }

        [TestMethod]
        public void TestConversion_non_valid_Int64_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Int64 result = xelem.ElementValueOrDefault<Int64>("nonvalid");
            Assert.AreEqual(default(Int64), result);
        }

        [TestMethod]
        public void TestConversion_valid_UInt16_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            UInt16 result = xelem.ElementValueOrDefault<UInt16>("uint16");
            Assert.AreEqual(UInt16.MaxValue, result);
        }

        [TestMethod]
        public void TestConversion_non_valid_UInt16_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            UInt16 result = xelem.ElementValueOrDefault<UInt16>("nonvalid");
            Assert.AreEqual(default(UInt16), result);
        }

        [TestMethod]
        public void TestConversion_valid_UInt32_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            UInt32 result = xelem.ElementValueOrDefault<UInt32>("uint32");
            Assert.AreEqual(UInt32.MaxValue, result);
        }

        [TestMethod]
        public void TestConversion_non_valid_UInt32_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            UInt32 result = xelem.ElementValueOrDefault<UInt32>("nonvalid");
            Assert.AreEqual(default(UInt32), result);
        }

        [TestMethod]
        public void TestConversion_valid_UInt64_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            UInt64 result = xelem.ElementValueOrDefault<UInt64>("uint64");
            Assert.AreEqual(UInt64.MaxValue, result);
        }

        [TestMethod]
        public void TestConversion_non_valid_UInt64_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            UInt64 result = xelem.ElementValueOrDefault<UInt64>("nonvalid");
            Assert.AreEqual(default(UInt64), result);
        }

        [TestMethod]
        public void TestConversion_valid_Single_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            //Single is 3.402823e38 so a UInt64 converts without problems
            Single result = xelem.ElementValueOrDefault<Single>("uint64");
            Assert.AreEqual(UInt64.MaxValue, result); 
        }

        [TestMethod]
        public void TestConversion_non_valid_Single_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Single result = xelem.ElementValueOrDefault<Single>("nonvalid");
            Assert.AreEqual(default(Single), result);
        }

        [TestMethod]
        public void TestConversion_valid_Double_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            //Double is 1.7976931348623157E+308 so a UInt64 converts without problems
            Double result = xelem.ElementValueOrDefault<Double>("uint64");
            Assert.AreEqual(UInt64.MaxValue, result);
        }

        [TestMethod]
        public void TestConversion_non_valid_Double_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Double result = xelem.ElementValueOrDefault<Double>("nonvalid");
            Assert.AreEqual(default(Double), result);
        }

        [TestMethod]
        public void TestConversion_valid_Boolean_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Boolean result = xelem.ElementValueOrDefault<Boolean>("bool");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestConversion_non_valid_Boolean_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Boolean result = xelem.ElementValueOrDefault<Boolean>("nonvalid");
            Assert.AreEqual(default(Boolean), result);
        }

        [TestMethod]
        public void TestConversion_valid_Char_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Char result = xelem.ElementValueOrDefault<Char>("char");
            Assert.AreEqual('c', result);
        }

        [TestMethod]
        public void TestConversion_non_valid_Char_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Char result = xelem.ElementValueOrDefault<Char>("nonvalid");
            Assert.AreEqual(default(Char), result);
        }

        [TestMethod]
        public void TestConversion_valid_Decimal_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Decimal result = xelem.ElementValueOrDefault<Decimal>("decimal");
            Assert.AreEqual((Decimal)25162.1378, result);
        }

        [TestMethod]
        public void TestConversion_non_valid_Decimal_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            Decimal result = xelem.ElementValueOrDefault<Decimal>("nonvalid");
            Assert.AreEqual(default(Decimal), result);
        }

        [TestMethod]
        public void TestConversion_valid_String_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            String result = xelem.ElementValueOrDefault<String>("string");
            Assert.AreEqual("Christian Giacomi", result);
        }

        [TestMethod]
        public void TestConversion_non_valid_String_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            String result = xelem.ElementValueOrDefault<String>("nonvalid");
            Assert.AreEqual(default(String), result);
        }

        [TestMethod]
        public void TestConversion_valid_DateTime_element_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();
            DateTime expected = new DateTime(1984, 01, 22);
            DateTime result = xelem.ElementValueOrDefault<DateTime>("datetime");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestConversion_non_valid_DateTime_element_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            DateTime result = xelem.ElementValueOrDefault<DateTime>("nonvalid");
            Assert.AreEqual(default(DateTime), result);
        }
    }
}
