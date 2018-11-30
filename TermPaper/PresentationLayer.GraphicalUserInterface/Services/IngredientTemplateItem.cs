using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.GraphicalUserInterface
{
    public class IngredientTemplateItem {
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public double Cost { get; set; }
        public double Weight { get; set; }

        public IngredientTemplateItem(string name, double cost, double weight, string imageSource) {
            Name = name;
            Cost = cost;
            Weight = weight;
            ImageSource = imageSource;
        }
    }
}
