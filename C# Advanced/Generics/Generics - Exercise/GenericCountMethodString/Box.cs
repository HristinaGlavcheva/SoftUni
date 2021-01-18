using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodString
{
    public class Box<T> where T : IComparable
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public void Add(T item)
        {
            this.data.Add(item);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            T firstValue = this.data[firstIndex];
            T secondValue = this.data[secondIndex];

            this.data[firstIndex] = secondValue;
            this.data[secondIndex] = firstValue;
        }

        public int CountGreaterItems(T item)
        {
            int count = 0;

            foreach (var currentItem in this.data)
            {
                bool isGreater = currentItem.CompareTo(item) > 0;

                if(isGreater)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in data)
            {
                sb.AppendLine($"{item.GetType().ToString()}: {item}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
