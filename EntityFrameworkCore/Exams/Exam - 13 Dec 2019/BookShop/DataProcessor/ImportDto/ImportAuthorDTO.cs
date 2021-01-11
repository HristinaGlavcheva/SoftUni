using BookShop.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorDTO
    {
        [Required, MinLength(3), MaxLength(30)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(30)]
        public string LastName { get; set; }

        //[Required, RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        [Required, RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [JsonProperty("Books")]
        public List<ImportBookIdDTO> Books  { get; set; }
    }

    public class ImportBookIdDTO
    {
        [JsonProperty("Id")]
        public int? BookId { get; set; }
    }
}

 
