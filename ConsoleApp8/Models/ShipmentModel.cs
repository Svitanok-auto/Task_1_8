using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleApp8.Models
{
    public class ShipmentModel
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("orders")]
        public List<OrderModel> Orders { get; set; }
        public string ID { get; set; }

      
    }
}
