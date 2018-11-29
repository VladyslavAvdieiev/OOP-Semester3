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

    public static class Converter {

        public static List<TemplateItem> ToTemplateItem(List<Ingredient> ingredients) {
            List<TemplateItem> items = new List<TemplateItem>();
            foreach (Ingredient ingredient in ingredients)
                items.Add(new TemplateItem(ingredient.Name, ingredient.Cost, ingredient.Weight));
            return items;
        }

        public static List<TemplateItem> ToTemplateItem(List<Dish> dishes) {
            List<TemplateItem> items = new List<TemplateItem>();
            foreach (Dish dish in dishes) {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + dish.ImageSource);
                image.EndInit();
                items.Add(new TemplateItem(dish.Name, dish.Description, dish.Cost, dish.Weight, dish.Time,
                          dish.Ingredients, image, new SolidColorBrush(Colors.WhiteSmoke)));    // TODO 1. random colors
            }
            return items;
        }

        public static List<Ingredient> ToIngredients(List<TemplateItem> items) {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (TemplateItem item in items)
                ingredients.Add(new Ingredient(item.Name, item.Cost, item.Weight));
            return ingredients;
        }

        public static List<Dish> ToDishes(List<TemplateItem> items) {
            List<Dish> dishes = new List<Dish>();
            foreach (TemplateItem item in items)
                dishes.Add(new Dish(item.Name, item.Description, item.Cost, item.Weight, item.Ingredients));
            return dishes;
        }
    }
}
