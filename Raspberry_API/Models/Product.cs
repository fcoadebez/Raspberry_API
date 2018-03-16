using System;
using Interface_Mongo_Http;
using Newtonsoft.Json;

namespace Raspberry_API.Models
{
    public class Product :IProduct
    {
        [JsonProperty(PropertyName = "MachineId")]
        public string MachineId { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "CurrentStock")]
        public int CurrentStock { get; set; }
        [JsonProperty(PropertyName = "MaxStock")]
        public int MaxStock { get; set; }
        [JsonProperty(PropertyName = "ImageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "Category")]
        public string Category { get; set; }
    }
}
