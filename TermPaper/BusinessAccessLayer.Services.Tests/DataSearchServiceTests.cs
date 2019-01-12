using System;
using System.Collections.Generic;
using Xunit;

namespace BusinessAccessLayer.Services.Tests
{
    public class DataSearchServiceTests {
        private static List<TestObject> testObjects = new List<TestObject>() { new TestObject(199, "Aster"),
                                                                               new TestObject(472, "Begonia"),
                                                                               new TestObject(641, "Gladiolus"),
                                                                               new TestObject(850, "Iris"),
                                                                               new TestObject(320, "Jasmine") };
        private static IDataAccessor<TestObject> dataAccessor = new TestDataAccessService<TestObject>(testObjects);

        public static IEnumerable<object[]> GetDataForFindByKeyMethod() {
            yield return new object[] { "Gladiolus", new TestObject(641, "Gladiolus") };
            yield return new object[] { "320", new TestObject(320, "Jasmine") };
            yield return new object[] { "Ast", new TestObject(199, "Aster") };
            yield return new object[] { "###", null };
        }

        public static IEnumerable<object[]> GetDataForFindAllByKeyMethod() {
            yield return new object[] { "4", new List<TestObject>() { new TestObject(472, "Begonia"),
                                                                      new TestObject(641, "Gladiolus") } };
            yield return new object[] { "as", new List<TestObject>() { new TestObject(320, "Jasmine") } };
            yield return new object[] { "###", new List<TestObject>() };
        }

        public static IEnumerable<object[]> GetDataForFindLastByKeyMethod() {
            yield return new object[] { "4", new TestObject(641, "Gladiolus") };
            yield return new object[] { "0", new TestObject(320, "Jasmine") };
            yield return new object[] { "###", null };
        }

        [Theory]
        [MemberData(nameof(GetDataForFindByKeyMethod))]
        public void FindByKey_TryToFindObjectInListByKey_Should_ReturnObject(string key, TestObject expected) {
            /*Arrange*/
            TestObject actual;

            /*Act*/
            actual = DataSearchService<TestObject>.FindByKey(dataAccessor, key);

            /*Assert*/
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForFindAllByKeyMethod))]
        public void FindAllByKey_TryToFindObjectsInListByKey_Should_ReturnListOfObjects(string key, List<TestObject> expected) {
            /*Arrange*/
            List<TestObject> actual;

            /*Act*/
            actual = DataSearchService<TestObject>.FindAllByKey(dataAccessor, key);

            /*Assert*/
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForFindLastByKeyMethod))]
        public void FindLastByKey_TryToFindObjectInListByKey_Should_ReturnObject(string key, TestObject expected) {
            /*Arrange*/
            TestObject actual;

            /*Act*/
            actual = DataSearchService<TestObject>.FindLastByKey(dataAccessor, key);

            /*Assert*/
            Assert.Equal(expected, actual);
        }
    }
}
