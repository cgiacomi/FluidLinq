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
        private string xmlDoc = "<book ISBN='1-861001-57-5'><title>Pride And Prejudice</title><price>19.95</price></book>";

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
        public void TestGetXDocument_valid_xnode_success()
        {
            XmlNode root = doc.FirstChild;

            XDocument xdoc = root.GetXDocument();
            Assert.IsNotNull(xdoc);
            Assert.IsFalse(xdoc.Root.IsEmpty);
            Assert.AreEqual("book", xdoc.Root.Name.LocalName);          
        }

        [TestMethod, ExpectedException(typeof(InvokeMethodFromNullObjectException))]
        public void TestGetXDocument_null_xnode_exception()
        {
            XmlNode root = null;
            root.GetXDocument();
        }

        [TestMethod]
        public void TestGetXElement_valid_xnode_success()
        {
            XmlNode root = doc.FirstChild;

            XElement xelem = root.GetXElement();
            Assert.IsNotNull(xelem);
            Assert.IsFalse(xelem.IsEmpty);
            Assert.AreEqual("book", xelem.Name.LocalName);
        }

        [TestMethod, ExpectedException(typeof(InvokeMethodFromNullObjectException))]
        public void TestGetXElement_null_xnode_exception()
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
        public void TestOuterXml_valid_xelement_success()
        {
            XmlNode root = doc.FirstChild;
            XElement xelem = root.GetXElement();

            string result = xelem.OuterXml();
            Assert.IsNotNull(result);
        }
    }
}
