using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

using FluidLinq;
using System.Xml.Linq;

namespace FluidLinqTest
{
    [TestClass]
    public class ExtensionsTest
    {
        private XmlDocument doc;
        private string xmlDoc = "<book ISBN=\"978-0330258647\" pages=\"180\" rating=\"9.5\" available=\"true\"><title>The Hitchhiker's Guide To The Galaxy</title><price>6.99</price><published>12 Oct 1979</published></book>";

        [TestInitialize]
        public void Setup()
        {
            doc = new XmlDocument();
            doc.LoadXml(xmlDoc);
        }

        [TestCleanup]
        public void Teardown()
        {
        }

        [TestMethod]
        public void TestGetXDocument_valid_xmlnode_success()
        {
            XmlNode root = doc.FirstChild;

            XDocument xdoc = root.GetXDocument();
            Assert.IsNotNull(xdoc);
            Assert.IsFalse(xdoc.Root.IsEmpty);
            Assert.AreEqual("book", xdoc.Root.Name.LocalName);          
        }

        [TestMethod, ExpectedException(typeof(InvokeMethodFromNullObjectException))]
        public void TestGetXDocument_null_xmlnode_exception()
        {
            XmlNode root = null;
            root.GetXDocument();
        }

        [TestMethod]
        public void TestGetXElement_valid_xmlnode_success()
        {
            XmlNode root = doc.FirstChild;

            XElement xelem = root.GetXElement();
            Assert.IsNotNull(xelem);
            Assert.IsFalse(xelem.IsEmpty);
            Assert.AreEqual("book", xelem.Name.LocalName);
        }

        [TestMethod, ExpectedException(typeof(InvokeMethodFromNullObjectException))]
        public void TestGetXElement_null_xmlnode_exception()
        {
            XmlNode root = null;
            root.GetXElement();
        }

        [TestMethod]
        public void TestGetXmlNode_valid_xelement_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            XmlNode node = xelem.GetXmlNode();
            Assert.IsNotNull(node);
            Assert.AreEqual("book", node.FirstChild.Name);
        }

        [TestMethod, ExpectedException(typeof(InvokeMethodFromNullObjectException))]
        public void TestGetXmlNode_null_xelement_exception()
        {
            XElement xelem = null;
            xelem.GetXmlNode();
        }

        [TestMethod]
        public void Test_valid_xelement_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            string result = xelem.OuterXml();
            Assert.IsNotNull(result);
            Assert.AreEqual(this.xmlDoc, result);
        }

        [TestMethod, ExpectedException(typeof(InvokeMethodFromNullObjectException))]
        public void TestOuterXml_null_xelement_exception()
        {
            XElement xelem = null;
            xelem.OuterXml();
        }

        [TestMethod]
        public void TestInnerXml_valid_xelement_success()
        {
            string innerXml = "<title>The Hitchhiker's Guide To The Galaxy</title><price>6.99</price><published>12 Oct 1979</published>";
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            string result = xelem.InnerXml();
            Assert.IsNotNull(result);
            Assert.AreEqual(innerXml, result);
        }

        [TestMethod, ExpectedException(typeof(InvokeMethodFromNullObjectException))]
        public void TestInnerXml_null_xelement_exception()
        {
            XElement xelem = null;
            xelem.InnerXml();
        }

        [TestMethod]
        public void TestAttributeValueOrDefault_valid_string_attribute_name_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            string result = xelem.AttributeValueOrDefault<string>("ISBN");
            Assert.IsNotNull(result);
            Assert.AreEqual("978-0330258647", result);
        }

        [TestMethod]
        public void TestAttributeValueOrDefault_wrong_string_attribute_name_returns_null()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            string result = xelem.AttributeValueOrDefault<string>("invalid_attribute");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestAttributeValueOrDefault_valid_int_attribute_name_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            int result = xelem.AttributeValueOrDefault<int>("pages");
            Assert.IsNotNull(result);
            Assert.AreEqual(180, result);
        }

        [TestMethod]
        public void TestAttributeValueOrDefault_wrong_int_attribute_name_returns_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            int result = xelem.AttributeValueOrDefault<int>("invalid_attribute");
            Assert.IsNotNull(result);
            Assert.AreEqual(default(int), result);
        }

        [TestMethod]
        public void TestAttributeValueOrDefault_valid_long_attribute_name_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            long result = xelem.AttributeValueOrDefault<long>("pages");
            Assert.IsNotNull(result);
            Assert.AreEqual(180, result);
        }

        [TestMethod]
        public void TestAttributeValueOrDefault_wrong_long_attribute_name_returns_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            long result = xelem.AttributeValueOrDefault<long>("invalid_attribute");
            Assert.IsNotNull(result);
            Assert.AreEqual(default(long), result);
        }

        [TestMethod]
        public void TestAttributeValueOrDefault_valid_bool_attribute_name_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            bool result = xelem.AttributeValueOrDefault<bool>("available");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestAttributeValueOrDefault_wrong_bool_attribute_name_returns_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            bool result = xelem.AttributeValueOrDefault<bool>("invalid_attribute");
            Assert.AreEqual(default(bool), result);
        }

        [TestMethod]
        public void TestAttributeValueOrDefault_valid_float_attribute_name_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            float result = xelem.AttributeValueOrDefault<float>("rating");
            Assert.AreEqual(9.5, result);
        }

        [TestMethod]
        public void TestAttributeValueOrDefault_wrong_float_attribute_name_returns_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            float result = xelem.AttributeValueOrDefault<float>("invalid_attribute");
            Assert.AreEqual(default(float), result);
        }

        [TestMethod]
        public void TestElementValueOrDefault_valid_datetime_element_name_success()
        {
            DateTime expected = new DateTime(1979, 10, 12);
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            DateTime result = xelem.ElementValueOrDefault<DateTime>("published");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestElementValueOrDefault_wrong_datetime_element_name_returns_default()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            DateTime result = xelem.ElementValueOrDefault<DateTime>("invalid_attribute");
            Assert.AreEqual(default(DateTime), result);
        }

        [TestMethod]
        public void TestAttributeValueOrDefault_null_xelement_returns_default()
        {
            XElement xelem = null;

            int result = xelem.AttributeValueOrDefault<int>("ISBN");
            Assert.IsNotNull(result);
            Assert.AreEqual(default(int), result);
        }
    }
}
