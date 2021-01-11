using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecipesApp.Models
{
    [Table("Recipes")] //ако искаме да зададем име на таблицата - по default се опитва да го образува като мн. число от името на класа, но има изкл. -> Mouse - Мice, а не Mouses
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Column("Title", Order =3, TypeName = "nvarchar(50)")]
        [Required]
        public string Name { get; set; }

        [NotMapped] //Ignore - Няма такава колона в БД (например за помощно property, business logic property)
        public string Description => $"{this.Name} ({this.CookingTime})";

        public TimeSpan? CookingTime { get; set; }


        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
