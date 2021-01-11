using Cinema.Data.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Cinema.DataProcessor.ImportDto
{
    public class ImportMovieDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Title { get; set; }

        [Range(0, 9)]
        public Genre Genre { get; set; }

        [Required]
        public string Duration { get; set; }

        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Director { get; set; }
    }
}

//{
//    "Title": "Little Big Man",
//    "Genre": "Western",
//    "Duration": "01:58:00",
//    "Rating": 28,
//    "Director": "Duffie Abrahamson"
//  },



