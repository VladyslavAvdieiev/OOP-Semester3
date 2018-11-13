using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessAccessLayer.Entities.Tests
{
    [TestClass]
    public class IngredientTests {

        [TestMethod]
        public void Cost_SetValidValueToCost_Should_SetValueToCost() {
            // Arrange
            double actual;
            double expected = 1.0;
            Ingredient ingredient = new Ingredient();

            // Act
            ingredient.Cost = expected;
            actual = ingredient.Cost;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Cost_SetNonValidValueToCost_Should_ThrowFormatExeption() {
            // Arrange
            double expected = -1.0;
            Ingredient ingredient = new Ingredient();

            // Act
            ingredient.Cost = expected;

            // Assert
        }

        [TestMethod]
        public void Weight_SetValidValueToWeight_Should_SetValueToWeight() {
            // Arrange
            double actual;
            double expected = 1.0;
            Ingredient ingredient = new Ingredient();

            // Act
            ingredient.Weight = expected;
            actual = ingredient.Weight;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Weight_SetNonValidValueToWeight_Should_ThrowFormatExeption() {
            // Arrange
            double expected = -1.0;
            Ingredient ingredient = new Ingredient();

            // Act
            ingredient.Weight = expected;

            // Assert
        }

        [TestMethod]
        public void ConstructorWithParameters_CreateIngredientUsingConstructorWithParameters_Should_SetAllValues() {
            // Arrange
            string name = "Default name";
            double cost = 1.0;
            double weight = 1.0;
            Ingredient actual;
            Ingredient expected = new Ingredient() { Name = name, Cost = cost, Weight = weight };

            // Act
            actual = new Ingredient(name, cost, weight);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyConstructor_CreateIngredientUsingCopyConstructor_Should_CopyAllValues() {
            // Arrange
            string name = "Default name";
            double cost = 1.0;
            double weight = 1.0;
            Ingredient actual;
            Ingredient expected = new Ingredient() { Name = name, Cost = cost, Weight = weight };

            // Act
            actual = new Ingredient(expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_CompareTwoIdenticalIngredients_Should_ReturnTrue() {
            // Arrange
            bool actual;
            Ingredient ingredient1 = new Ingredient() { Name = "Default name", Cost = 1.0, Weight = 1.0 };
            Ingredient ingredient2 = new Ingredient() { Name = "Default name", Cost = 1.0, Weight = 1.0 };

            // Act
            actual = ingredient1.Equals(ingredient2);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Equals_CompareTwoNonIdenticalIngredients_Should_ReturnFalse() {
            // Arrange
            bool actual;
            Ingredient ingredient1 = new Ingredient() { Name = "Default name", Cost = 1.0, Weight = 1.0 };
            Ingredient ingredient2 = new Ingredient() { Name = "Different name", Cost = 2.0, Weight = 2.0 };

            // Act
            actual = ingredient1.Equals(ingredient2);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Equals_CompareIngredientWithDifferentType_Should_ThrowFormatExeption() {
            // Arrange
            bool actual;
            int differentObject = 1;
            Ingredient ingredient = new Ingredient() { Name = "Default name", Cost = 1.0, Weight = 1.0 };

            // Act
            actual = ingredient.Equals(differentObject);

            // Assert
        }
    }
}
