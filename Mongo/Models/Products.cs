﻿using Interface_Mongo_Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo
{
    public class Product:IProduct
    {
        public ObjectId Id { get; set; }
        [BsonElement("machine_id")]
        public string MachineId { get; set; }
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