using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Services.Tests
{
    public class TestObject {

        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }

        public TestObject(string name, string description, double cost) {
            Name = name;
            Description = description;
            Cost = cost;
        }

        public override string ToString() {
            return $"Name:{Name} - Cost:{Cost} - Description:{Description}";
        }
    }
}
