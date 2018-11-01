using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{
    public class LinkedStack<T> : IEnumerable<T> {

        private Node<T> Head { get; set; }

        public int Count { get; private set; }

        public void Clear() {
            Head = null;
            Count = 0;
        }

        public T Peek() {
            if (Count == 0)
                throw new IndexOutOfRangeException("Stack is empty.");
            return Head.Value;
        }

        public T Pop() {
            if (Count == 0)
                throw new IndexOutOfRangeException("Stack is empty.");
            T temp = Head.Value;
            Head = Head.Next;
            Count--;
            return temp;
        }

        public void Push(T item) {
            Node<T> node = new Node<T>(item) { Next = Head };
            Head = node;
            Count++;
        }

        public T[] ToArray() {
            int i = 0;
            T[] array = new T[Count];
            for (Node<T> current = Head; current != null; current = current.Next)
                array[i++] = current.Value;
            return array;
        }

        public IEnumerator<T> GetEnumerator() {
            for (Node<T> current = Head; current != null; current = current.Next)
                yield return current.Value;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
