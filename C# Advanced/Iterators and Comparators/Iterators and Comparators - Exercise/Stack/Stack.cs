using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> data;
        private int count;

        public Stack()
        {
            this.data = new List<T>();
            this.Count = count;
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            this.data.Add(item);

            this.Count++;
        }

        public T Pop()
        {
            if(this.Count == 0)
            {
                throw new Exception("No elements");
            }
            
            var lastItem = this.data[this.data.Count - 1];
            this.data.RemoveAt(this.data.Count - 1);
            this.Count--;

            return lastItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
