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
    // TODO 1. random colors
    // TODO 2. random colors
    // TODO 3. random colors
    // TODO 4. random colors

    public static class Converter {

        public static List<IngredientTemplateItem> ToIngredientTemplateItem(List<Ingredient> ingredients) {
            List<IngredientTemplateItem> items = new List<IngredientTemplateItem>();
            foreach (Ingredient ingredient in ingredients)
                items.Add(new IngredientTemplateItem(ingredient.Name, ingredient.Cost, ingredient.Weight, ingredient.ImageSource));
            return items;
        }


        public static List<TemplateItem> ToTemplateItem(List<Ingredient> ingredients) {
            List<TemplateItem> items = new List<TemplateItem>();
            foreach (Ingredient ingredient in ingredients)
                items.Add(new TemplateItem(ingredient.Name, ingredient.Cost, ingredient.Weight, ingredient.ImageSource,
                                           new SolidColorBrush(Colors.WhiteSmoke)));     // TODO 1. random colors
            return items;
        }

        public static TemplateItem ToTemplateItem(Ingredient ingredient) {
            TemplateItem item = new TemplateItem(ingredient.Name, ingredient.Cost, ingredient.Weight,
                                                 ingredient.ImageSource, new SolidColorBrush(Colors.WhiteSmoke));   // TODO 2. random colors
            return item;
        }

        public static List<TemplateItem> ToTemplateItem(List<Dish> dishes) {
            List<TemplateItem> items = new List<TemplateItem>();
            foreach (Dish dish in dishes)
                items.Add(new TemplateItem(dish.Name, dish.Description, dish.Cost, dish.Weight, dish.Time,
                                           dish.ImageSource, dish.Ingredients, new SolidColorBrush(Colors.WhiteSmoke)));     // TODO 3. random colors
            return items;
        }

        public static TemplateItem ToTemplateItem(Dish dish) {
            TemplateItem item = new TemplateItem(dish.Name, dish.Description, dish.Cost, dish.Weight, dish.Time,
                                                 dish.ImageSource, dish.Ingredients, new SolidColorBrush(Colors.WhiteSmoke));   // TODO 4. random colors
            return item;
        }

        public static List<Ingredient> ToIngredients(List<IngredientTemplateItem> items) {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (IngredientTemplateItem item in items)
                ingredients.Add(new Ingredient(item.Name, item.Cost, item.Weight, item.ImageSource));
            return ingredients;
        }

        public static List<Ingredient> ToIngredients(List<TemplateItem> items) {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (TemplateItem item in items)
                ingredients.Add(new Ingredient(item.Name, item.Cost, item.Weight, item.ImageSource));
            return ingredients;
        }

        public static List<Dish> ToDishes(List<TemplateItem> items) {
            List<Dish> dishes = new List<Dish>();
            foreach (TemplateItem item in items)
                dishes.Add(new Dish(item.Name, item.Description, item.Cost, item.Time, item.ImageSource, item.Ingredients));
            return dishes;
        }
    }
}
