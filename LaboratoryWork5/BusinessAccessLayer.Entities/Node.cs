using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Entities
{
    class Node<T> {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node(T value) { Value = value; }
        public override string ToString() { return Value.ToString(); }
    }
}
