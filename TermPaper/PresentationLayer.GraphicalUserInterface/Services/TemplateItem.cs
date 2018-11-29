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
    public class TemplateItem {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public double Weight { get; set; }
        public double Time { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public BitmapImage Icon { get; set; }
        public SolidColorBrush Background { get; set; }

        public TemplateItem() {
            Ingredients = new List<Ingredient>();
        }

        /// <summary>
        /// Constructor for Ingredients
        /// </summary>
        public TemplateItem(string name, double cost, double weight) {
            Name = name;
            Cost = cost;
            Weight = weight;
        }

        /// <summary>
        /// Constructor for Dishes
        /// </summary>
        public TemplateItem(string name, string description, double cost, double weight, double time,
                            List<Ingredient> ingredients, BitmapImage icon, SolidColorBrush background) {
            Name = name;
            Description = description;
            Cost = cost;
            Weight = weight;
            Time = time;
            Ingredients = ingredients;
            Icon = icon;
            Background = background;
        }
    }
}
