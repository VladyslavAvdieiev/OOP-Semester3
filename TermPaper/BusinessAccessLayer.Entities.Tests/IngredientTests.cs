using System;
using Xunit;

namespace BusinessAccessLayer.Entities.Tests
{
    public class IngredientTests {

        #region Properties
        #region Name
        [Theory]
        [InlineData("Test name1")]
        [InlineData("Test name2")]
        public void Name_SetValueToName_Should_SetNameCorreclty(string expected) {
            /*Arrange*/
            string actual;
            Ingredient ingredient = new Ingredient();

            /*Act*/
            ingredient.Name = expected;
            actual = ingredient.Name;

            /*Assert*/
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Cost
        [Theory]
        [InlineData(5.0)]
        [InlineData(50.0)]
        public void Cost_SetValidValueToCost_Should_SetCostCorreclty(double expected) {
            /*Arrange*/
            double actual;
            Ingredient ingredient = new Ingredient();

            /*Act*/
            ingredient.Cost = expected;
            actual = ingredient.Cost;

            /*Assert*/
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-5.0)]
        [InlineData(-50.0)]
        public void Cost_SetInvalidValueToCost_Should_ThrowFormatExeption(double expected) {
            /*Arrange*/
            Ingredient ingredient = new Ingredient();

            /*Act & Assert*/
            Assert.Throws<FormatException>(() => ingredient.Cost = expected);
        }
        #endregion

        #region Weight
        [Theory]
        [InlineData(5.0)]
        [InlineData(50.0)]
        public void Weight_SetValidValueToWeight_Should_SetWeightCorreclty(double expected) {
            /*Arrange*/
            double actual;
            Ingredient ingredient = new Ingredient();

            /*Act*/
            ingredient.Weight = expected;
            actual = ingredient.Weight;

            /*Assert*/
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-5.0)]
        [InlineData(-50.0)]
        public void Weight_SetInvalidValueToWeight_Should_ThrowFormatExeption(double expected) {
            /*Arrange*/
            Ingredient ingredient = new Ingredient();

            /*Act & Assert*/
            Assert.Throws<FormatException>(() => ingredient.Weight = expected);
        }
        #endregion
        #endregion

        #region Constructors
        #region Constructor with parameters
        [Theory]
        [InlineData("Test name1", 5.0, 5.0)]
        [InlineData("Test name2", 50.0, 50.0)]
        public void ConstructorWithParameters_CreateInstance_Should_SetAllValuesCorrectly(string name, double cost, double weight) {
            /*Arrange & Act*/
            Ingredient expected = new Ingredient { Name = name, Cost = cost, Weight = weight };
            Ingredient actual = new Ingredient(name, cost, weight);

            /*Assert*/
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Copy constructor
        [Theory]
        [InlineData("Test name1", 5.0, 5.0)]
        [InlineData("Test name2", 50.0, 50.0)]
        public void CopyConstructor_CreateInstance_Should_SetAllValuesCorrectly(string name, double cost, double weight) {
            /*Arrange & Act*/
            Ingredient expected = new Ingredient { Name = name, Cost = cost, Weight = weight };
            Ingredient actual = new Ingredient(expected);

            /*Assert*/
            Assert.Equal(expected, actual);
        }
        #endregion
        #endregion

        #region Equals
        [Theory]
        [InlineData("Test name1", 5.0, 5.0)]
        [InlineData("Test name2", 50.0, 50.0)]
        public void Equals_CompareTwoIdenticalIngredients_Should_ReturnTrue(string name, double cost, double weight) {
            /*Arrange*/
            bool actual;
            Ingredient ingredient1 = new Ingredient { Name = name, Cost = cost, Weight = weight };
            Ingredient ingredient2 = new Ingredient { Name = name, Cost = cost, Weight = weight };

            /*Act*/
            actual = ingredient1.Equals(ingredient2);

            /*Assert*/
            Assert.True(actual);
        }

        [Theory]
        [InlineData("Test name1", 5.0, 5.0)]
        [InlineData("Test name2", 50.0, 50.0)]
        public void Equals_CompareTwoDifferentIngredients_Should_ReturnFalse(string name, double cost, double weight) {
            /*Arrange*/
            bool actual;
            Ingredient ingredient1 = new Ingredient { Name = name, Cost = cost, Weight = weight };
            Ingredient ingredient2 = new Ingredient { Name = name + 5, Cost = cost + 5, Weight = weight + 5 };

            /*Act*/
            actual = ingredient1.Equals(ingredient2);

            /*Assert*/
            Assert.False(actual);
        }

        [Theory]
        [InlineData(new int())]
        [InlineData(new char())]
        public void Equals_CompareIngredientWithDifferentType_Should_ThrowFormatExeption<TDiffType>(TDiffType diffType) {
            /*Arrange*/
            Ingredient ingredient = new Ingredient();

            /*Act & Assert*/
            Assert.Throws<FormatException>(() => ingredient.Equals(diffType));
        }
        #endregion
    }
}
