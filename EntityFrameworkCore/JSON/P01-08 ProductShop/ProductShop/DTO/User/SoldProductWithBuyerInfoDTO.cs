using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProductShop.DTO.User
{
    public class SoldProductWithBuyerInfoDTO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("soldProducts")]
        public List<UserSoldProductDTO> SoldProducts { get; set; }
    }
}
