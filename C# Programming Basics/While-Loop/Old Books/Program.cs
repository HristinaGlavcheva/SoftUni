using System;

namespace Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());
            string nextBook = "";
            int checkedBooks = 0; 

            while (nextBook != favouriteBook && checkedBooks <= capacity)
            {
                if (checkedBooks == capacity)
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {checkedBooks} books.");
                    break;
                }
                
                nextBook = Console.ReadLine();
                if (nextBook == favouriteBook)
                {
                    Console.WriteLine($"You checked {checkedBooks} books and found it.");
                    break;
                }

                checkedBooks++;
            }

        }
    }
}
