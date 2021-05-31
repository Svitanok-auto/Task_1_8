using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApp8.Models
{
    public class CustomersModel
    {
        [JsonProperty("customers")]
        public List<CustomerModel> Customers { get; set; }
    }
}
