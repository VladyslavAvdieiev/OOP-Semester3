﻿using System;
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

        public List<Dish> Dishes { get; }

        public int TableNumber { get => _tableNumber; set => _tableNumber = value; }

        public string Remark { get => _remark; set => _remark = value; }

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
            Dishes = new List<Dish>();
        }

        public Order(int tableNumber) {
            Dishes = new List<Dish>();
            TableNumber = tableNumber;
        }

        public Order(int tableNumber, double cost) {
            Dishes = new List<Dish>();
            TableNumber = tableNumber;
            Cost = cost;
        }

        public Order(int tableNumber, List<Dish> dishes) {
            Dishes = DeepCopy(dishes);
            TableNumber = tableNumber;
        }

        public Order(int tableNumber, double cost, List<Dish> dishes) {
            Dishes = DeepCopy(dishes);
            TableNumber = tableNumber;
            Cost = cost;
        }

        public Order(Order order) {
            Dishes = DeepCopy(order.Dishes);
            TableNumber = order.TableNumber;
            Remark = order.Remark;
        }

        private List<Dish> DeepCopy(List<Dish> dishes) {
            List<Dish> result = new List<Dish>();
            foreach (Dish temp in dishes)
                result.Add(new Dish(temp));
            return result;
        }
    }
}