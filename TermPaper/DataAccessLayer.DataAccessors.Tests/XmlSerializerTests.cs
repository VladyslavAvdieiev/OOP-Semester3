using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccessLayer.DataAccessors.Tests
{
    [TestClass]
    public class XmlSerializerTests {

        [TestMethod]
        public void DefaultConstructor_CreateNonGenericTypeSerializer_NonGenericTypeFilePathReturned() {
            // Arrange
            string actual;
            string expected = "Int32.xml";
            ISerializer<int> serializer = new XmlSerializer<int>();

            // Act
            actual = serializer.FilePath;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultConstructor_CreateGenericTypeSerializer_GenericTypeFilePathReturned() {
            // Arrange
            string actual;
            string expected = "Int32.xml";
            ISerializer<List<int>> serializer = new XmlSerializer<List<int>>();

            // Act
            actual = serializer.FilePath;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithParameters_CreateSerializerWithConstructorWithParameters_FilePathReturned() {
            // Arrange
            string actual;
            string expected = "ExpectedFilePath.xml";
            ISerializer<int> serializer = new XmlSerializer<int>(expected);

            // Act
            actual = serializer.FilePath;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
