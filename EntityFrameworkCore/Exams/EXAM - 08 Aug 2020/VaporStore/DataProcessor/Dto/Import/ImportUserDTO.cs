using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string FullName { get; set; }

        //TODO: Validate Email with attribute in DTO
        [Required]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        public List<Card> Cards { get; set; }
    }

    public class ImportCardDTO
    {
        [Required]
        [RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}$")]
        public string Cvc { get; set; }

        [Required]
        [Range(0, 1)]
        public CardType Type { get; set; }
    }
}

//{
//		"FullName": "",
//		"Username": "invalid",
//		"Email": "invalid@invalid.com",
//		"Age": 20,
//		"Cards": [
//			{
//				"Number": "1111 1111 1111 1111",
//				"CVC": "111",
//				"Type": "Debit"
//			}
//		]
//	},



