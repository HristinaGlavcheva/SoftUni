﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WorkShopLab
{
    class MyList
    {
        private int capacity;
        private int[] data;

        public MyList()
            :this(4)
        {
            //this.data = new int[4];
        }
        
        public MyList(int capacity)
        {
            this.capacity = capacity;
            this.data = new int[capacity];
        }

        public int Count { get; private set; }
        
        public void Add(int number)
        {
            this.CheckIfResizeIsNeeded();
            
            this.data[this.Count] = number;

            this.Count++;
        }

        public int this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this.data[index];
            }

            set
            {
                this.ValidateIndex(index);

                this.data[index] = value;
            }

        }

        public void Clear()
        {
            this.Count = 0;
            this.data = new int[this.capacity];
        }

        private void CheckIfResizeIsNeeded()
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }
        }

        private void Resize()
        {
            var newCapacity = this.data.Length * 2;

            var newData = new int[newCapacity];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }

        public void Insert(int index, int element)
        {
            this.ValidateIndex(index);
            this.CheckIfResizeIsNeeded();

            for (int i = this.Count - 1; i >= index; i--)
            {
                this.data[i + 1] = this.data[i];
            }

            this.data[index] = element;

            this.Count++;
        }

        public int RemoveAt(int index)
        {
            this.ValidateIndex(index);

            var result = this.data[index];

            for (int i = index + 1; i < this.Count; i++)
            {
                this.data[i - 1] = this.data[i];
            }

            this.Count--;

            return result;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if(this.data[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);

            int firstNumber = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = firstNumber;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
