using System;
using BusinessAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace PresentationLayer.GraphicalUserInterface
{
    public static class Converter {

        /// <summary>
        /// Plural: Ingredients to IngredientTemplateItem
        /// </summary>
        public static List<IngredientTemplateItem> ToIngredientTemplateItem(List<Ingredient> ingredients) {
            List<IngredientTemplateItem> items = new List<IngredientTemplateItem>();
            foreach (Ingredient ingredient in ingredients)
                items.Add(new IngredientTemplateItem(ingredient.Name, ingredient.Cost, ingredient.Weight, ingredient.ImageSource));
            return items;
        }

        /// <summary>
        /// Singular: Ingredient to IngredientTemplateItem
        /// </summary>
        public static IngredientTemplateItem ToIngredientTemplateItem(Ingredient ingredient) {
            IngredientTemplateItem item = new IngredientTemplateItem(ingredient.Name, ingredient.Cost, ingredient.Weight, ingredient.ImageSource);
            return item;
        }

        /// <summary>
        /// Plural: IngredientTemplateItem to Ingredients
        /// </summary>
        public static List<Ingredient> ToIngredients(List<IngredientTemplateItem> items) {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (IngredientTemplateItem item in items)
                ingredients.Add(new Ingredient(item.Name, item.Cost, item.Weight, item.ImageSource));
            return ingredients;
        }

        /// <summary>
        /// Singular: IngredientTemplateItem to Ingredient
        /// </summary>
        public static Ingredient ToIngredients(IngredientTemplateItem item) {
            Ingredient ingredient = new Ingredient(item.Name, item.Cost, item.Weight, item.ImageSource);
            return ingredient;
        }
    }
}
