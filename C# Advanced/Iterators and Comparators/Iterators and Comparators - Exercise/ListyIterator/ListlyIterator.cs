using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListlyIterator
{
    public class ListlyIterator<T> : IEnumerable<T>
    {
        private List<T> data;
        private int currentIndex;

        public ListlyIterator(params T[] data)
        {
            this.data = new List<T>(data);
        }

        public bool Move()
        {
            //if(index < data.Count)
            //{
            //    index++;
            //    return true;
            //}
            //return false;

            if (this.HasNext())
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (currentIndex < data.Count - 1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.data[this.currentIndex]);
        }

        public void PrintAll()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            foreach (var item in this.data)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        //private class CollectionItarator : IEnumerator<T>
        //{
        //    private int currentIndex;
        //    private readonly List<T> data;

        //    public CollectionItarator(IEnumerable<T> data)
        //    {
        //        this.Reset();
        //        this.data = new List<T>(data);
        //    }

        //    public T Current
        //    {
        //        get { return this.data[this.currentIndex]; }
        //    }

        //    object IEnumerator.Current => this.Current;

        //    public void Dispose()
        //    {
        //    }

        //    public bool MoveNext()
        //    {
        //        if (this.currentIndex < data.Count - 1)
        //        {
        //            this.currentIndex++;
        //            return true;
        //        }

        //        return false;
        //    }

        //    public void Reset()
        //    {
        //        this.currentIndex = 0;
        //    }
        //}
    }
}
