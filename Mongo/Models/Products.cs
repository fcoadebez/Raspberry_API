using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MVC6_WEBAPI_MongoDB.Models
{
    public class Product
    {
        public ObjectId Id { get; set; }
        [BsonElement("machine_id")]
        public int MachineId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("current_stock")]
        public int CurrentStock { get; set; }
        [BsonElement("max_stock")]
        public int MaxStock { get; set; }
        [BsonElement("image_url")]
        public string ImageUrl { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }

    }
}