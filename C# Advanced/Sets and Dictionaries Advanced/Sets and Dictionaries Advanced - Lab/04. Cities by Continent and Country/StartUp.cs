using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countLines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < countLines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>(); 
                }

                Dictionary<string, List<string>> countries = continents[continent];

                if (!countries.ContainsKey(country))
                {
                    countries[country] = new List<string>();
                }

                List<string> cities = countries[country];

                cities.Add(city);
            }

            foreach (var (contitent, countries) in continents)
            {
                Console.WriteLine($"{contitent}:");

                foreach (var (country, cities) in countries)
                {
                    Console.WriteLine($"  {country} -> {String.Join(", ", cities)}");
                }
            }
        }
    }
}
