using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Entities
{
    [Serializable]
    public class Ingredient {
        private string _name;
        private string _imageSource;
        private double _cost;
        private double _weight;

        public string Name { get => _name; set => _name = value; }

        public string ImageSource { get => _imageSource; set => _imageSource = value; }

        public double Cost {
            get => _cost;
            set {
                if (value < 0)
                    throw new FormatException("Cost cannot be less than 0.");
                _cost = value;
            }
        }

        public double Weight {
            get => _weight;
            set {
                if (value < 0)
                    throw new FormatException("Weight cannot be less than 0.");
                _weight = value;
            }
        }

        public Ingredient() {

        }

        public Ingredient(string name, double cost, double weigth) {
            Name = name;
            Cost = cost;
            Weight = weigth;
        }

        public Ingredient(string name, double cost, double weigth, string imageSource) {
            Name = name;
            Cost = cost;
            Weight = weigth;
            ImageSource = imageSource;
        }

        public Ingredient(Ingredient ingredient) {
            Name = ingredient.Name;
            Cost = ingredient.Cost;
            Weight = ingredient.Weight;
            ImageSource = ingredient.ImageSource;
        }

        public override bool Equals(object obj) {
            if (obj == null)
                return false;
            if (obj is Ingredient ingredient)
                return GetHashCode() == ingredient.GetHashCode();
            throw new FormatException("Incoming object is not an 'Ingredient' type.");
        }

        public static bool operator ==(Ingredient ingredient1, Ingredient ingredient2) {
            return ingredient1.Equals(ingredient2);
        }

        public static bool operator !=(Ingredient ingredient1, Ingredient ingredient2) {
            return !ingredient1.Equals(ingredient2);
        }

        public override int GetHashCode() {
            return ToString().GetHashCode();
        }

        public override string ToString() {
            return $"Name:{Name} - Cost:{Cost} - Weight:{Weight}";
        }
    }
}
