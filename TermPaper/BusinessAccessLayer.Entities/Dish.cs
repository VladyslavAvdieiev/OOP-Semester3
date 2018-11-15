﻿using System;
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
        private double _cost;
        private double _time;

        public List<Ingredient> Ingredients { get; }

        public string Name { get => _name; set => _name = value; }

        public string Description { get => _description; set => _description = value; }

        public double Cost {
            get => _cost;
            set {
                double minimum = MinimumCost();
                if (value < minimum)
                    throw new FormatException($"Cost cannot be less than {minimum}.");
                _cost = value;
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

        public Dish(string name, string description, double cost, double time, List<Ingredient> ingredients) {
            Ingredients = DeepCopy(ingredients);
            Description = description;
            Name = name;
            Cost = cost;
            Time = time;
        }

        public Dish(Dish dish) {
            Ingredients = DeepCopy(dish.Ingredients);
            Description = dish.Description;
            Name = dish.Name;
            Cost = dish.Cost;
            Time = dish.Time;
        }

        private List<Ingredient> DeepCopy(List<Ingredient> ingredients) {
            List<Ingredient> result = new List<Ingredient>();
            foreach (Ingredient temp in ingredients)
                result.Add(new Ingredient(temp.Name, temp.Cost, temp.Weight));
            return result;
        }

        public double MinimumCost() {
            double sum = 0.0;
            foreach (Ingredient ingredient in Ingredients)
                sum += ingredient.Cost;
            return sum;
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
            return $"Name:{Name} - Cost:{Cost} - Weight:{Weight} - Time:{Time}";
        }
    }
}
