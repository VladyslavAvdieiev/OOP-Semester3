using System;
using System.Collections.Generic;
using Xunit;

namespace DataAccessLayer.DataAccessors.Tests
{
    public class XmlSerializerTests {

        #region Default constructor
        [Fact]
        public void DefaultCoustructor_CreateInstanceWithNonGenericType_Should_SetFilePathCorreclty() {
            /*Arrange*/
            ISerializer<int> serializer = new XmlSerializer<int>();

            /*Act*/
            string actual = serializer.FilePath;

            /*Assert*/
            Assert.Equal("Int32.xml", actual);
        }

        [Fact]
        public void DefaultCoustructor_CreateInstanceWithGenericType_Should_SetFilePathCorreclty() {
            /*Arrange*/
            ISerializer<List<int>> serializer = new XmlSerializer<List<int>>();

            /*Act*/
            string actual = serializer.FilePath;

            /*Assert*/
            Assert.Equal("Int32.xml", actual);
        }
        #endregion
    }
}
