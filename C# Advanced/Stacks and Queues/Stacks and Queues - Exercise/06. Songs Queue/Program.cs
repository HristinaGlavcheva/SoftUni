using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputSongs = Console.ReadLine()
                .Split(", ");

            Queue<string> songs = new Queue<string>(inputSongs);

            while (songs.Any())
            {
                string command = Console.ReadLine();

                if(command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command.StartsWith("Add"))
                {
                    string songName = command.Substring(4);

                    if (songs.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(songName);
                    }
                }
                if (command == "Show")
                {
                    Console.WriteLine(String.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
