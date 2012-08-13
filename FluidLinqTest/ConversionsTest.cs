using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Xml.Linq;
using FluidLinq;

namespace FluidLinqTest
{
    using System.Globalization;

    using Extensions = FluidLinq.Extensions;

    [TestClass]
    public class ConversionsTest
    {
        private static XmlDocument simpleXmlDocument;

        static ConversionsTest()
        {
            simpleXmlDocument = new XmlDocument();
            simpleXmlDocument.Load("simpletestdata.xml");
        }

        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void TestConversion_RegisterNewConversion_Success()
        {
            Extensions.AddConversionMap<TestStub>((s, from) => new TestStub { Value = s });
            Assert.IsTrue(true); 
            Extensions.RemoveConversionMap(typeof(TestStub));
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestConversion_RegisterTwice_Fail()
        {
            Extensions.AddConversionMap<TestStub>((s, from) => new TestStub { Value = s });
            Extensions.AddConversionMap<TestStub>((s, from) => new TestStub { Value = s });
            Extensions.RemoveConversionMap(typeof(TestStub));
        }

        public class TestStub
        {
            public string Value { get; set; }
        }

        #region Byte mapping tests

        [TestMethod]
        public void TestConversion_ValidByteConversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("byte");

            var result = selectedElements.ConvertTo<Byte>();

            Assert.AreEqual(Byte.MaxValue, result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidByteConversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Byte>();

            Assert.AreEqual(default(Byte), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidByteConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Byte>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(Byte), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidByteConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("byte");

            var result = selectedElements.ConvertTo<Byte>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(Byte.MaxValue, result.Single());
        }

        #endregion

        #region SByte mapping tests

        [TestMethod]
        public void TestConversion_ValidSByteConversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("sbyte");

            var result = selectedElements.ConvertTo<SByte>();

            Assert.AreEqual(SByte.MaxValue, result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidSByteConversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<SByte>();

            Assert.AreEqual(default(SByte), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidSByteConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<SByte>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(SByte), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidSByteConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("sbyte");

            var result = selectedElements.ConvertTo<SByte>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(SByte.MaxValue, result.Single());
        }

        #endregion

        #region Int16 mapping tests

        [TestMethod]
        public void TestConversion_ValidInt16Conversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("int16");

            var result = selectedElements.ConvertTo<Int16>();

            Assert.AreEqual(Int16.MaxValue, result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidInt16Conversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Int16>();

            Assert.AreEqual(default(Int16), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidInt16ConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Int16>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(Int16), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidInt16ConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("int16");

            var result = selectedElements.ConvertTo<Int16>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(Int16.MaxValue, result.Single());
        }

        #endregion

        #region UInt16 mapping tests

        [TestMethod]
        public void TestConversion_ValidUInt16Conversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("uint16");

            var result = selectedElements.ConvertTo<UInt16>();

            Assert.AreEqual(UInt16.MaxValue, result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidUInt16Conversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<UInt16>();

            Assert.AreEqual(default(UInt16), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidUInt16ConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<UInt16>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(UInt16), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidUInt16ConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("uint16");

            var result = selectedElements.ConvertTo<UInt16>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(UInt16.MaxValue, result.Single());
        }

        #endregion

        #region Int32 mapping tests

        [TestMethod]
        public void TestConversion_ValidInt32Conversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("int32");

            var result = selectedElements.ConvertTo<Int32>();

            Assert.AreEqual(Int32.MaxValue, result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidInt32Conversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Int32>();

            Assert.AreEqual(default(Int32), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidInt32ConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Int32>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(Int32), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidInt32ConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("int32");

            var result = selectedElements.ConvertTo<Int32>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(Int32.MaxValue, result.Single());
        }

        #endregion

        #region UInt32 mapping tests

        [TestMethod]
        public void TestConversion_ValidUInt32Conversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("uint32");

            var result = selectedElements.ConvertTo<UInt32>();

            Assert.AreEqual(UInt32.MaxValue, result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidUInt32Conversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<UInt32>();

            Assert.AreEqual(default(UInt32), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidUInt32ConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<UInt32>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(UInt32), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidUInt32ConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("uint32");

            var result = selectedElements.ConvertTo<UInt32>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(UInt32.MaxValue, result.Single());
        }

        #endregion

        #region Int64 mapping tests

        [TestMethod]
        public void TestConversion_ValidInt64Conversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("int64");

            var result = selectedElements.ConvertTo<Int64>();

            Assert.AreEqual(Int64.MaxValue, result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidInt64Conversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Int64>();

            Assert.AreEqual(default(Int64), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidInt64ConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Int64>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(Int64), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidInt64ConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("int64");

            var result = selectedElements.ConvertTo<Int64>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(Int64.MaxValue, result.Single());
        }

        #endregion

        #region UInt64 mapping tests

        [TestMethod]
        public void TestConversion_ValidUInt64Conversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("uint64");

            var result = selectedElements.ConvertTo<UInt64>();

            Assert.AreEqual(UInt64.MaxValue, result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidUInt64Conversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<UInt64>();

            Assert.AreEqual(default(UInt64), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidUInt64ConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<UInt64>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(UInt64), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidUInt64ConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("uint64");

            var result = selectedElements.ConvertTo<UInt64>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(UInt64.MaxValue, result.Single());
        }

        #endregion

        #region Single mapping tests

        [TestMethod]
        public void TestConversion_ValidSingleConversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("single");

            var result = selectedElements.ConvertTo<Single>();

            Assert.AreEqual(1.11111f, result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidSingleConversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Single>();

            Assert.AreEqual(default(Single), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidUSingleConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Single>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(Single), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidSingleConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("single");

            var result = selectedElements.ConvertTo<Single>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(1.11111f, result.Single());
        }

        #endregion

        #region Double mapping tests

        [TestMethod]
        public void TestConversion_ValidDoubleConversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("decimal");

            var result = selectedElements.ConvertTo<Double>();

            Assert.AreEqual(25162.1378d, result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidDoubleConversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Double>();

            Assert.AreEqual(default(Double), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidUDoubleConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Double>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(Double), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidDoubleConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("decimal");

            var result = selectedElements.ConvertTo<Double>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(25162.1378d, result.Single());
        }

        #endregion

        #region Boolean mapping tests

        [TestMethod]
        public void TestConversion_ValidBooleanConversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("bool");

            var result = selectedElements.ConvertTo<Boolean>();

            Assert.AreEqual(true, result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidBooleanConversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Boolean>();

            Assert.AreEqual(default(Boolean), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidBooleanConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Boolean>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(Boolean), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidBooleanConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("bool");

            var result = selectedElements.ConvertTo<Boolean>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(true, result.Single());
        }

        #endregion

        #region Char mapping tests

        [TestMethod]
        public void TestConversion_ValidCharConversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("char");

            var result = selectedElements.ConvertTo<Char>();

            Assert.AreEqual('c', result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidCharConversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Char>();

            Assert.AreEqual(default(Char), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidCharConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Char>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(Char), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidCharConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("char");

            var result = selectedElements.ConvertTo<Char>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual('c', result.Single());
        }

        #endregion

        #region Decimal mapping tests

        [TestMethod]
        public void TestConversion_ValidDecimalConversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("decimal");

            var result = selectedElements.ConvertTo<Decimal>();

            Assert.AreEqual(25162.1378m, result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidDecimalConversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Decimal>();

            Assert.AreEqual(default(Decimal), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidDecimalConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<Decimal>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(Decimal), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidDecimalConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("decimal");

            var result = selectedElements.ConvertTo<Decimal>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(25162.1378m, result.Single());
        }

        #endregion

        #region String mapping tests

        [TestMethod]
        public void TestConversion_ValidStringConversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("string");

            var result = selectedElements.ConvertTo<String>();

            Assert.AreEqual("Christian Giacomi", result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidStringConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("string");

            var result = selectedElements.ConvertTo<String>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual("Christian Giacomi", result.Single());
        }

        #endregion

        #region DateTime mapping tests

        [TestMethod]
        public void TestConversion_ValidDateTimeConversion_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("datetime");

            var result = selectedElements.ConvertTo<DateTime>();

            Assert.AreEqual(DateTime.Parse("01/22/1984", CultureInfo.InvariantCulture), result.Single());
        }

        [TestMethod]
        public void TestConversion_NonValidDateTimeConversion_ReturnsDefault()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<DateTime>();

            Assert.AreEqual(default(DateTime), result.Single());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestConversion_NonValidDateTimeConversionAlternateBehaviour_ThrowsExceptions()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("nonvalid");

            var result = selectedElements.ConvertTo<DateTime>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(default(DateTime), result.Single());
        }

        [TestMethod]
        public void TestConversion_ValidDateTimeConversionAlternateBehaviour_Success()
        {
            var selectedElements = SelectElementsFromSimpleTestXml("datetime");

            var result = selectedElements.ConvertTo<DateTime>(ErrorBehaviour.ErrorsThrowExceptions);

            Assert.AreEqual(DateTime.Parse("01/22/1984", CultureInfo.InvariantCulture), result.Single());
        }

        #endregion

        private static IEnumerable<XElement> SelectElementsFromSimpleTestXml(string elementName)
        {
            var selectedElements = from elem in simpleXmlDocument.ToXDocument().Root.Descendants() where elem.Name == elementName select elem;
            return selectedElements;
        }
    }
}
