using Recipes.Models;
using System;

namespace Recipes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new RecipesDbContext();
            db.Database.EnsureCreated();

            db.Recipes.Add(new Recipe { Name = "Musaka" });
            db.SaveChanges();
        }
    }
}
