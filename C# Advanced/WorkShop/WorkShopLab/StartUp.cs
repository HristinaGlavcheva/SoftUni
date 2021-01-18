using System;

namespace WorkShopLab
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var list = new MyList(100);

            list.Add(10);
            list.Add(20);
            list.Add(30);

            var count = list.Count; //3

            Console.WriteLine(count);

            list[0] = 100;

            var number = list[1];

            list.Clear();

            Console.WriteLine(list.Count);

            //list[4] = 500;

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            Console.WriteLine(list.Count);

            var newList = new MyList();

            newList.Add(1);
            newList.Add(2);
            newList.Add(3);
            newList.Add(4);
            newList.Add(5);

            var removed = newList.RemoveAt(4);

            for (int i = 0; i < newList.Count; i++)
            {
                Console.WriteLine(newList[i]);
            }

            Console.WriteLine(newList.Count);
            Console.WriteLine(removed);

            Console.WriteLine(newList.Contains(5));
            Console.WriteLine(newList.Contains(1));

            newList.Swap(0, 2);

            for (int i = 0; i < newList.Count; i++)
            {
                Console.WriteLine(newList[i]);
            }

            //-------------------------------------------------------------------

            var stack = new MyStack();

            stack.Push(10);
            stack.Push(20);

            Console.WriteLine(stack.Count); //2

            var popResult =  stack.Pop();

            Console.WriteLine(popResult); //20;

            var peekResult = stack.Peek();

            Console.WriteLine(peekResult); //10;

            Console.WriteLine(stack.Count); //1

            stack.Clear();

            Console.WriteLine(stack.Count); //0

            var newStack = new MyStack();

            for (int i = 0; i < 3; i++)
            {
                newStack.Push(i);
            }

            //Console.WriteLine(newStack.Pop());
            //Console.WriteLine(newStack.Pop());
            //Console.WriteLine(newStack.Pop());
            //Console.WriteLine(newStack.Pop());

            Console.WriteLine(newStack.Peek());
            Console.WriteLine(newStack.Peek());
            Console.WriteLine(newStack.Peek());
            Console.WriteLine(newStack.Peek());
            Console.WriteLine(newStack.Peek());
            Console.WriteLine(newStack.Peek());
            Console.WriteLine(newStack.Peek());

            newStack.ForEach(n => Console.WriteLine(n * 10));

            var nextList = new MyList();

            nextList.Add(1);
            nextList.Add(2);
            nextList.Add(3);
            nextList.Add(4);

            nextList.Insert(2, 100);

            Console.WriteLine(nextList[2]); //100
            Console.WriteLine(nextList[3]); //3
            Console.WriteLine(nextList[4]); //4


        }
    }
}
