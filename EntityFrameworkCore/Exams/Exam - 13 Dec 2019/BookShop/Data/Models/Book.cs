
namespace BookShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    using BookShop.Data.Models.Enums;

    public class Book
    {
        public Book()
        {
            this.AuthorsBooks = new HashSet<AuthorBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        [Required] //Requred e по default, защото е Enum (ще си го преобразува в int, което е notnullabe по default), може и без този атрибут
        public Genre Genre { get; set; }

        //[Range(0.01, double.MaxValue)] //Валидацията се случва на при импорта, затова тук може и да не се задава Range
        public decimal Price { get; set; }

        //[Range(50, 5000)] //Валидацията се случва на при импорта, тук може и да не се задава Range
        public int Pages { get; set; }

        [Required] //Requred e по default, може и без този атрибут
        public DateTime PublishedOn { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}
