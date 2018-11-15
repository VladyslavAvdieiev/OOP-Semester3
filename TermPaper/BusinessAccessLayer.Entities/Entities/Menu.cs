using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Entities
{
    [Serializable]
    public class Menu {
        private string _name;
        private string _description;
        
        public List<Dish> Dishes { get; }

        public string Name { get => _name; set => _name = value; }

        public string Description { get => _description; set => _description = value; }

        public Menu() {
            Dishes = new List<Dish>();
        }

        public Menu(string name, string description) {
            Dishes = new List<Dish>();
            Description = description;
            Name = name;
        }

        public Menu(string name, string description, List<Dish> dishes) {
            Dishes = DeepCopy(dishes);
            Description = description;
            Name = name;
        }

        private List<Dish> DeepCopy(List<Dish> dishes) {
            List<Dish> result = new List<Dish>();
            foreach (Dish temp in dishes)
                result.Add(new Dish(temp));
            return result;
        }

        public override string ToString() {
            return $"Name:{Name} - Description:{Description}";
        }
    }
}
