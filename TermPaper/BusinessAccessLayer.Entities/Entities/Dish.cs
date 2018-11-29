using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Entities
{
    [Serializable]
    public class Dish {
        private string _name;
        private string _description;
        private string _imageSource;
        private double _cost;
        private double _time;

        public List<Ingredient> Ingredients { get; }

        public string Name { get => _name; set => _name = value; }

        public string Description { get => _description; set => _description = value; }

        public string ImageSource { get => _imageSource; set => _imageSource = value; }

        public double Cost {
            get => _cost;
            set {
                if (value < 0)
                    throw new FormatException("Cost cannot be less than 0.");
                _cost = value;
            }
        }

        public double DefaultCost {
            get {
                double cost = 0.0;
                foreach (Ingredient ingredient in Ingredients)
                    cost += ingredient.Cost;
                return cost;
            }
        }

        public double Weight {
            get {
                double weight = 0.0;
                foreach (Ingredient ingredient in Ingredients)
                    weight += ingredient.Weight;
                return weight;
            }
        }

        public double Time {
            get => _time;
            set {
                if (value < 0)
                    throw new FormatException("Time cannot be less than 0.");
                _time = value;
            }
        }

        public Dish() {
            Ingredients = new List<Ingredient>();
        }

        public Dish(string name, string description, double cost, double time) {
            Ingredients = new List<Ingredient>();
            Description = description;
            Name = name;
            Cost = cost;
            Time = time;
        }

        public Dish(string name, string description, double cost, double time, string imageSource) {
            Ingredients = new List<Ingredient>();
            Description = description;
            Name = name;
            Cost = cost;
            Time = time;
            ImageSource = imageSource;
        }

        public Dish(string name, string description, double cost, double time, List<Ingredient> ingredients) {
            Ingredients = DeepCopy(ingredients);
            Description = description;
            Name = name;
            Cost = cost;
            Time = time;
        }

        public Dish(string name, string description, double cost, double time, string imageSource, List<Ingredient> ingredients) {
            Ingredients = DeepCopy(ingredients);
            Description = description;
            Name = name;
            Cost = cost;
            Time = time;
            ImageSource = imageSource;
        }

        public Dish(Dish dish) {
            Ingredients = DeepCopy(dish.Ingredients);
            Description = dish.Description;
            Name = dish.Name;
            Cost = dish.Cost;
            Time = dish.Time;
            ImageSource = dish.ImageSource;
        }

        private List<Ingredient> DeepCopy(List<Ingredient> ingredients) {
            List<Ingredient> result = new List<Ingredient>();
            foreach (Ingredient temp in ingredients)
                result.Add(new Ingredient(temp));
            return result;
        }

        public override bool Equals(object obj) {
            if (obj is Dish dish) {
                if (GetHashCode() != dish.GetHashCode())
                    return false;
                if (Ingredients.Count != dish.Ingredients.Count)
                    return false;
                for (int i = 0; i < Ingredients.Count; i++)
                    if (Ingredients[i] != dish.Ingredients[i])
                        return false;
                return true;
            }
            throw new FormatException("Incoming object is not an 'Dish' type.");
        }

        public static bool operator ==(Dish dish1, Dish dish2) {
            return dish1.Equals(dish2);
        }

        public static bool operator !=(Dish dish1, Dish dish2) {
            return !dish1.Equals(dish2);
        }

        public override int GetHashCode() {
            return ToString().GetHashCode();
        }

        public override string ToString() {
            return $"Name:{Name} - Cost:{Cost} - Weight:{Weight} - Time:{Time} - Description:{Description}";
        }
    }
}
