using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleApp8.Models
{
    public class OrderModel
    {
        [JsonProperty("typeOfGoods")]
        public string TypeOfGoods { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
        public int ID { get; set; }
    }
}
