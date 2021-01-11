using Microsoft.EntityFrameworkCore;
using RecipesApp.Data;
using RecipesApp.Models;
using System;

namespace RecipesApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new RecipesDbContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            //при всяка първа инициализация на DbContext сравнява миграциите
            db.Database.Migrate();

            db.Recipes.Add(new Recipe {
                Name = "Musaka", 
                Description = "Traditional Bulgarian/Turkish meal", 
                CookingTime = new TimeSpan(1, 20, 0)});
            db.SaveChanges();


        }
    }
}
