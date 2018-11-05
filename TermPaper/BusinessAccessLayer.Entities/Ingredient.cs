using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Entities
{
    public class Ingredient {
        private string _name;
        private float _cost;
        private float _weight;

        public string Name { get => _name; set => _name = value; }

        public float Cost {
            get => _cost;
            set {
                if (value < 0)
                    throw new FormatException("Cost cannot be less than 0.");
                _cost = value;
            }
        }

        public float Weight {
            get => _weight;
            set {
                if (value < 0)
                    throw new FormatException("Weight cannot be less than 0.");
                _weight = value;
            }
        }

        public Ingredient() {

        }

        public Ingredient(string name, float cost, float weigth) {
            Name = name;
            Cost = cost;
            Weight = weigth;
        }

        public Ingredient(Ingredient ingredient) {
            Name = ingredient.Name;
            Cost = ingredient.Cost;
            Weight = ingredient.Weight;
        }

        public override bool Equals(object obj) {
            if (obj is Ingredient ingredient)
                return ToString() == ingredient.ToString();
            throw new FormatException("Incoming object is not an 'Ingredient' type.");
        }

        public override int GetHashCode() {
            return ToString().GetHashCode();
        }

        public override string ToString() {
            return $"Name:{Name} - Cost:{Cost} - Weight:{Weight}";
        }
    }
}
