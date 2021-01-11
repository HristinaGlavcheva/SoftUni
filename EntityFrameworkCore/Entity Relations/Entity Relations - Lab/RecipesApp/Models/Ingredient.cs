using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesApp.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")] // и без атрибут EF Core си го прави като foreignKey и си прави колона RecipeId - int, без дори да има такова Property
        public Recipe Recipe { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}
