using System;

namespace _06._Favorite_Movie
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            int countFilms = 0;
            int pointsPerFilm = 0;
            int maxPoints = 0;
            string bestMovie = "";

            while (filmName != "STOP")
            {
                for (int index = 0; index <= filmName.Length - 1; index++)
                {
                    char currentSymbol = filmName[index];
                    
                    if (currentSymbol >= 97 && currentSymbol <= 122)
                    {
                        pointsPerFilm += currentSymbol - 2 * filmName.Length;

                    }
                    else if (currentSymbol >= 65 && currentSymbol <= 90)
                    {
                        pointsPerFilm += currentSymbol - filmName.Length;
                    }
                    else
                    {
                        pointsPerFilm += currentSymbol;
                    }
                }

                if (pointsPerFilm > maxPoints)
                {
                    maxPoints = pointsPerFilm;
                    bestMovie = filmName;
                }

                pointsPerFilm = 0;
                filmName = Console.ReadLine();
                countFilms++;
                if (countFilms == 7)
                {
                    Console.WriteLine("The limit is reached.");
                    break;
                }
            }

            Console.WriteLine($"The best movie for you is {bestMovie} with {maxPoints} ASCII sum.");
        }
    }
}
