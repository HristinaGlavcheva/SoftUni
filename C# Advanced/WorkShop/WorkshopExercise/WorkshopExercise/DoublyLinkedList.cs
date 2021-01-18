using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public int this[int index]
        {
            get
            {
                int[] arr = this.ToArray();

                if(index < 0 || index >= arr.Length)
                {
                    throw new ArgumentException("Index outside of the bounds of the list.", nameof(index));
                }

                return arr[index];
            }
        }

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if(this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newHead = new ListNode<T>(element);
                ListNode<T> oldHead = this.head;

                this.head = newHead;
                newHead.NextNode = oldHead;
                oldHead.PreviousNode = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if(this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newTail = new ListNode<T>(element);
                ListNode<T> oldTail = this.tail;

                this.tail = newTail;
                newTail.PreviousNode = oldTail;
                oldTail.NextNode = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            T removedEl = this.head.Value;
            
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }
            else if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode<T> newHead = this.head.NextNode;
                newHead.PreviousNode = null;
                this.head = newHead;
            }

            this.Count--;

            return removedEl;
        }

        public T RemoveLast()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }

            T removedElement = this.tail.Value;

            if(this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode<T> newTail = this.tail.PreviousNode;
                newTail.NextNode = null;
                this.tail = newTail;
            }

            this.Count--;

            return removedElement;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentEl = this.head;

            while (currentEl != null)
            {
                action(currentEl.Value);
                currentEl = currentEl.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];
            
            int counter = 0;

            ListNode<T> currentEl = this.head;

            while(currentEl != null)
            {
                arr[counter] = currentEl.Value;
                counter++;
                currentEl = currentEl.NextNode;
            }

            return arr;
        }


    }
}
