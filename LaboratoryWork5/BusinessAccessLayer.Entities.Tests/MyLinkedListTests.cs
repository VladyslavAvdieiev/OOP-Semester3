using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessAccessLayer.Entities.Tests
{
    [TestClass]
    public class MyLinkedListTests {

        [TestMethod]
        public void Indexer_GetValidIndex_ItemReturned() {
            // Arrange
            int actual;
            int index = 1;
            int expected = 2;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // Act
            actual = list[index];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_GetNotValidIndex_IndexOutOfRangeException() {
            // Arrange
            int actual;
            int index = 100;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // Act
            actual = list[index];

            // Assert
        }

        [TestMethod]
        public void Add_AddOneItem_TheSameItemReturned() {
            // Arrange
            int actual;
            int index = 0;
            int expected = 1;
            MyLinkedList<int> list = new MyLinkedList<int>() { expected };

            // Act
            actual = list[index];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Clear_RemoveAllItems_IndexOutOfRangeException() {
            // Arrange
            int actual;
            int index = 0;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // Act
            list.Clear();
            actual = list[index];

            // Assert
        }

        [TestMethod]
        public void Count_AddOneItem_CountReturned() {
            // Arrange
            int actual;
            int expected = 1;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1 };

            // Act
            actual = list.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Count_RemoveAllItems_CountReturned() {
            // Arrange
            int actual;
            int expected = 0;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // Act
            list.Clear();
            actual = list.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Contains_TryToFindItemInList_TrueReturned() {
            // Arrange
            bool actual;
            int item = 2;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // Act
            actual = list.Contains(item);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Contains_TryToFindItemInList_FalseReturned() {
            // Arrange
            bool actual;
            int item = 100;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // Act
            actual = list.Contains(item);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CopyTo_AddArrayToList_ListWithTheSameItemsReturned() {
            // Arrange
            int[] items = new int[] { 1, 2, 3, 4, 5 };
            int arrayIndex = 1;
            MyLinkedList<int> actual = new MyLinkedList<int>();
            MyLinkedList<int> expected = new MyLinkedList<int>() { 2, 3, 4, 5 };

            // Act
            actual.CopyTo(items, arrayIndex);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CopyTo_AddArrayToList_IndexOutOfRangeException() {
            // Arrange
            int[] items = new int[] { 1, 2, 3, 4 };
            int arrayIndex = 100;
            MyLinkedList<int> actual = new MyLinkedList<int>();

            // Act
            actual.CopyTo(items, arrayIndex);

            // Assert
        }

        [TestMethod]
        public void IndexOf_GetIndexOfValidItem_IndexReturned() {
            // Arrange
            int actual;
            int item = 2;
            int expected = 1;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // Act
            actual = list.IndexOf(item);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOf_GetIndexOfNotValidItem_IndexReturned() {
            // Arrange
            int actual;
            int item = 100;
            int expected = -1;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // Act
            actual = list.IndexOf(item);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_InsertItemToHeadOfList_ListWithTheSameItemsReturned() {
            // Arrange
            int item = 100;
            int index = 0;
            MyLinkedList<int> actual = new MyLinkedList<int>() { 1, 2, 3, 4 };
            MyLinkedList<int> expected = new MyLinkedList<int>() { 100, 1, 2, 3, 4 };

            // Act
            actual.Insert(index, item);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_InsertItemToTailOfList_ListWithTheSameItemsReturned() {
            // Arrange
            int item = 100;
            int index = 4;
            MyLinkedList<int> actual = new MyLinkedList<int>() { 1, 2, 3, 4 };
            MyLinkedList<int> expected = new MyLinkedList<int>() { 1, 2, 3, 4, 100 };

            // Act
            actual.Insert(index, item);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_InsertItemToMiddleOfList_ListWithTheSameItemsReturned() {
            // Arrange
            int item = 100;
            int index = 3;
            MyLinkedList<int> actual = new MyLinkedList<int>() { 1, 2, 3, 4 };
            MyLinkedList<int> expected = new MyLinkedList<int>() { 1, 2, 3, 100, 4 };

            // Act
            actual.Insert(index, item);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Insert_InsertItemToOutOfRangeOfList_IndexOutOfRangeException() {
            // Arrange
            int item = 100;
            int index = 100;
            MyLinkedList<int> actual = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // Act
            actual.Insert(index, item);

            // Assert
        }

        [TestMethod]
        public void Remove_RemoveValidItemFromList_ListWithoutThisItemReturned() {
            // Arrange
            int item = 3;
            MyLinkedList<int> actual = new MyLinkedList<int>() { 1, 2, 3, 4 };
            MyLinkedList<int> expected = new MyLinkedList<int>() { 1, 2, 4 };

            // Act
            actual.Remove(item);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_RemoveValidItemFromList_TrueReturned() {
            // Arrange
            bool actual;
            int item = 2;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // Act
            actual = list.Remove(item);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Remove_RemoveNotValidItemFromList_FalseReturned() {
            // Arrange
            bool actual;
            int item = 100;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // Act
            actual = list.Remove(item);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void RemoveAt_RemoveItemFromHeadOfList_ListWithTheSameItemsReturned() {
            // Arrange
            int index = 0;
            MyLinkedList<int> actual = new MyLinkedList<int>() { 1, 2, 3, 4 };
            MyLinkedList<int> expected = new MyLinkedList<int>() { 2, 3, 4 };

            // Act
            actual.RemoveAt(index);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_RemoveItemFromTailOfList_ListWithTheSameItemsReturned() {
            // Arrange
            int index = 3;
            MyLinkedList<int> actual = new MyLinkedList<int>() { 1, 2, 3, 4 };
            MyLinkedList<int> expected = new MyLinkedList<int>() { 1, 2, 3 };

            // Act
            actual.RemoveAt(index);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_RemoveItemFromMiddleOfList_ListWithTheSameItemsReturned() {
            // Arrange
            int index = 1;
            MyLinkedList<int> actual = new MyLinkedList<int>() { 1, 2, 3, 4 };
            MyLinkedList<int> expected = new MyLinkedList<int>() { 1, 3, 4 };

            // Act
            actual.RemoveAt(index);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAt_RemoveItemFromOutOfRangeOfList_IndexOutOfRangeException() {
            // Arrange
            int index = 100;
            MyLinkedList<int> actual = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // Act
            actual.RemoveAt(index);

            // Assert
        }
    }
}
