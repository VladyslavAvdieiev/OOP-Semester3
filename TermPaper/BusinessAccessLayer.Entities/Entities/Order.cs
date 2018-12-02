using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Entities
{
    public class Order {
        private int _tableNumber;
        private string _remark;
        private double _cost;
        private List<Dish> _dishes;
        private DateTime _date;

        public List<Dish> Dishes {
            get => _dishes;
            set => _dishes = DeepCopy(value);
        }

        public int TableNumber {
            get => _tableNumber;
            set => _tableNumber = value;
        }

        public string Remark {
            get => _remark;
            set => _remark = value;
        }

        public DateTime Date {
            get => _date;
            set => _date = value;
        }

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
                foreach (Dish dish in Dishes)
                    cost += dish.Cost;
                return cost;
            }
        }

        public Order() {
            _dishes = new List<Dish>();
            Date = DateTime.Now;
        }

        public Order(int tableNumber, DateTime date) {
            _dishes = new List<Dish>();
            TableNumber = tableNumber;
            Date = date;
        }

        public Order(int tableNumber, double cost, DateTime date) {
            _dishes = new List<Dish>();
            TableNumber = tableNumber;
            Cost = cost;
            Date = date;
        }

        public Order(int tableNumber, List<Dish> dishes, DateTime date) {
            Dishes = dishes;
            TableNumber = tableNumber;
            Date = date;
        }

        public Order(int tableNumber, double cost, List<Dish> dishes, DateTime date) {
            Dishes = dishes;
            TableNumber = tableNumber;
            Cost = cost;
            Date = date;
        }

        public Order(Order order) {
            Dishes = DeepCopy(order.Dishes);
            TableNumber = order.TableNumber;
            Remark = order.Remark;
            Date = order.Date;
        }

        private List<Dish> DeepCopy(List<Dish> dishes) {
            List<Dish> result = new List<Dish>();
            foreach (Dish temp in dishes)
                result.Add(new Dish(temp));
            return result;
        }

        public override string ToString() {
            return $"Date:{Date} - Table:{TableNumber} - Cost:{Cost} - Remark:{Remark}";
        }
    }
}
