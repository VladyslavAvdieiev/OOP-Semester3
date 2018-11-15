using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessAccessLayer.Entities.Tests
{
    [TestClass]
    public class DishTests {

        [TestMethod]
        public void Cost_SetValidValueToCost_Should_SetValueToCost() {
            // Arrange
            double actual;
            double expected = 1.0;
            Dish dish = new Dish();

            // Act
            dish.Cost = expected;
            actual = dish.Cost;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Cost_SetNonValidValueToCost_Should_ThrowFormatExeption() {
            // Arrange
            double minCost = 2.0;
            double expected = 1.0;
            Dish dish = new Dish();

            // Act
            dish.Ingredients.Add(new Ingredient() { Cost = minCost });
            dish.Cost = expected;

            // Assert
        }

        [TestMethod]
        public void Weight_GetValidValueFromWeight_Should_GetSumOfIngredientsWeight() {
            // Arrange
            double actual;
            double expected = 1.0;
            Dish dish = new Dish();

            // Act
            dish.Ingredients.Add(new Ingredient() { Weight = 0.7 });
            dish.Ingredients.Add(new Ingredient() { Weight = 0.3 });
            actual = dish.Weight;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinimumCost_CountMinimumCost_Should_ReturnSumOfIngredientsCost() {
            // Arrange
            double actual;
            double expected = 1.0;
            Dish dish = new Dish();

            // Act
            dish.Ingredients.Add(new Ingredient() { Cost = 0.7 });
            dish.Ingredients.Add(new Ingredient() { Cost = 0.3 });
            actual = dish.MinimumCost();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Time_SetValidValueToTime_Should_SetValueToTime() {
            // Arrange
            double actual;
            double expected = 1.0;
            Dish dish = new Dish();

            // Act
            dish.Time = expected;
            actual = dish.Time;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Time_SetNonValidValueToTime_Should_ThrowFormatExeption() {
            // Arrange
            double expected = -1.0;
            Dish dish = new Dish();

            // Act
            dish.Time = expected;

            // Assert
        }

        [TestMethod]
        public void ConstructorWithParameters1_CreateDishUsingConstructorWithParameters1_Should_SetAllValues() {
            // Arrange
            string name = "Default name";
            string description = "Default description";
            double cost = 1.0;
            double time = 1.0;
            Dish actual;
            Dish expected = new Dish() { Name = name, Description = description, Cost = cost, Time = time };

            // Act
            actual = new Dish(name, description, cost, time);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithParameters2_CreateDishUsingConstructorWithParameters2_Should_SetAllValues() {
            // Arrange
            string name = "Default name";
            string description = "Default description";
            double cost = 1.0;
            double time = 1.0;
            Dish actual;
            Ingredient ingredient = new Ingredient("Default name", 1.0, 1.0);
            Dish expected = new Dish() { Name = name, Description = description, Cost = cost, Time = time };
            expected.Ingredients.Add(ingredient);

            // Act
            actual = new Dish(name, description, cost, time, new List<Ingredient>() { ingredient });

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyConstructor_CreateDishUsingCopyConstructor_Should_CopyAllValues() {
            // Arrange
            string name = "Default name";
            string description = "Default description";
            double cost = 1.0;
            double time = 1.0;
            Dish actual;
            Dish expected = new Dish() { Name = name, Description = description, Cost = cost, Time = time };

            // Act
            actual = new Dish(expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_CompareTwoIdenticalDishes_Should_ReturnTrue() {
            // Arrange
            bool actual;
            Dish dish1 = new Dish() { Name = "Default name", Description = "Default description", Cost = 1.0, Time = 1.0 };
            Dish dish2 = new Dish() { Name = "Default name", Description = "Default description", Cost = 1.0, Time = 1.0 };

            // Act
            dish1.Ingredients.Add(new Ingredient());
            dish2.Ingredients.Add(new Ingredient());
            actual = dish1.Equals(dish2);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Equals_CompareTwoNonIdenticalDishesByHashCode_Should_ReturnFalse() {
            // Arrange
            bool actual;
            Dish dish1 = new Dish() { Name = "Default name", Description = "Default description", Cost = 1.0, Time = 1.0 };
            Dish dish2 = new Dish() { Name = "Different name", Description = "Different description", Cost = 2.0, Time = 2.0 };

            // Act
            actual = dish1.Equals(dish2);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Equals_CompareTwoNonIdenticalDishesByCountOfIngredients_Should_ReturnFalse() {
            // Arrange
            bool actual;
            Dish dish1 = new Dish() { Name = "Default name", Description = "Default description", Cost = 1.0, Time = 1.0 };
            Dish dish2 = new Dish() { Name = "Different name", Description = "Different description", Cost = 2.0, Time = 2.0 };

            // Act
            dish2.Ingredients.Add(new Ingredient());
            actual = dish1.Equals(dish2);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Equals_CompareTwoNonIdenticalDishesByConditionOfIngredients_Should_ReturnFalse() {
            // Arrange
            bool actual;
            Dish dish1 = new Dish() { Name = "Default name", Description = "Default description", Cost = 1.0, Time = 1.0 };
            Dish dish2 = new Dish() { Name = "Different name", Description = "Different description", Cost = 2.0, Time = 2.0 };

            // Act
            dish1.Ingredients.Add(new Ingredient() { Name = "Default name"});
            dish2.Ingredients.Add(new Ingredient());
            actual = dish1.Equals(dish2);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Equals_CompareIngredientWithDifferentType_Should_ThrowFormatExeption() {
            // Arrange
            bool actual;
            int differentObject = 1;
            Dish dish = new Dish() { Name = "Default name", Description = "Default description", Cost = 1.0, Time = 1.0 };

            // Act
            actual = dish.Equals(differentObject);

            // Assert
        }
    }
}
