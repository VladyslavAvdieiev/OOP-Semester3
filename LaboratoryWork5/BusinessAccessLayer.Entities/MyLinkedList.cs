using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Entities
{
    public class MyLinkedList<T> : ICollection, IEnumerable<T> where T : IComparable {

        private Node<T> Head { get; set; }

        public int Count { get; private set; }

        public object SyncRoot { get; }

        public bool IsSynchronized { get; }

        public T this[int index] {
            get {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                Node<T> current = Head;
                for (int i = 0; i < index; i++)
                    current = current.Next;
                return current.Value;
            }
            set {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                Node<T> current = Head;
                for (int i = 0; i < index; i++)
                    current = current.Next;
                current.Value = value;
            }
        }

        public void Add(T item) {
            Node<T> current = Head;
            if (Head == null)
                Head = new Node<T>(item);
            else {
                for (int i = 0; i < Count - 1; i++)
                    current = current.Next;
                current.Next = new Node<T>(item);
            }
            Count++;
        }

        public void AddAhead(T item) {
            Head = new Node<T>(item) { Next = Head };
            Count++;
        }

        public void Clear() {
            Head = null;
            Count = 0;
        }
        
        public bool Contains(T item) {
            for (Node<T> current = Head; current != null; current = current.Next)
                if (current.Value.Equals(item))
                    return true;
            return false;
        }
        
        public void CopyTo(Array array, int arrayIndex) {
            if (arrayIndex >= array.Length)
                throw new IndexOutOfRangeException();
            Clear();
            for (int i = arrayIndex; i < array.Length; i++)
                Add((T)array.GetValue(i));
        }

        public IEnumerator<T> GetEnumerator() {
            for (Node<T> current = Head; current != null; current = current.Next)
                yield return current.Value;
        }
        
        public int IndexOf(T item) {
            int index = 0;
            for (Node<T> current = Head; current != null; current = current.Next, index++)
                if (current.Value.Equals(item))
                    return index;
            return -1;
        }
        
        public void Insert(int index, T item) {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException();
            else if (index == 0)
                AddAhead(item);
            else if (index == Count)
                Add(item);
            else {
                Node<T> current = Head;
                for (int i = 0; i < index - 1; i++)
                    current = current.Next;
                current.Next = new Node<T>(item) { Next = current.Next };
                Count++;
            }
        }
        
        public bool Remove(T item) {
            int index = 0;
            Node<T> current = Head;
            int test = current.Value.CompareTo(item);
            while (index != Count && current.Value.CompareTo(item) != 0) {
                current = current.Next;
                index++;
            }
            if (index == Count)
                return false;
            current = Head;
            for (int i = 0; i < index - 1; i++)
                current = current.Next;
            current.Next = current.Next.Next;
            Count--;
            return true;
        }
        
        public void RemoveAt(int index) {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            else if (index == 0)
                Head = Head.Next;
            else if (index == Count - 1) {
                Node<T> current = Head;
                for (int i = 0; i < index - 1; i++)
                    current = current.Next;
                current.Next = null;
            }
            else {
                Node<T> current = Head;
                for (int i = 0; i < index - 1; i++)
                    current = current.Next;
                current.Next = current.Next.Next;
            }
            Count--;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public override string ToString() {
            string result = string.Empty;
            for (int i = 0; i < Count; i++)
                result += $"{this[i]}  ";
            return result;
        }
    }
}
