using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApp8.Models
{
    public class CustomerModel
    {
        [JsonProperty("customer")]
        public string Customer { get; set; }
        [JsonProperty("shipment")]
        public List<ShipmentModel> Shipments { get; set; }
        public Guid ID { get; set; }
    }
}
