using System;

namespace _05._Movie_Ratings
{
    class Program
    {
        static void Main(string[] args)
        {
            int countFilms = int.Parse(Console.ReadLine());
            double highestRating = 0;
            double lowestRating = 10.1;
            double sumRatings = 0;
            string highestRatingFilm = string.Empty;
            string lowestRatingFilm = string.Empty;

            for (int counter = 1; counter <= countFilms; counter++)
            {
                string name = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());
                sumRatings += rating;

                if (rating > highestRating)
                {
                    highestRating = rating;
                    highestRatingFilm = name;
                }
                if (rating < lowestRating)
                {
                    lowestRating = rating;
                    lowestRatingFilm = name;
                }
            }

            double averageRating = sumRatings / countFilms;

            Console.WriteLine($"{highestRatingFilm} is with highest rating: {highestRating:F1}");
            Console.WriteLine($"{lowestRatingFilm} is with lowest rating: {lowestRating:F1}");
            Console.WriteLine($"Average rating: {averageRating:F1}");
        }
    }
}
