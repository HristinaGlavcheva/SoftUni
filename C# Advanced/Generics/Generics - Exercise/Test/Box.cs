using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Box<T>
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.data)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
