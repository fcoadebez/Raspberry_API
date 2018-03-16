using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Diagnostics;
using Interface_Mongo_Http;
using System.Linq;

namespace Mongo
{
    public class DataAccess : Interface
    {
        MongoClient _client;
        IMongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://ecv-app-iot:ecv123@ds237808.mlab.com:37808/app-iot");
            _db = _client.GetDatabase("app-iot");
        }

        public List<IProduct> GetProducts()
        {
            var test = _db.GetCollection<Product>("products").AsQueryable<Product>().ToList();

            return test.Cast<IProduct>().ToList();

        }

        public IProduct GetProduct(string name)
        {
            var filter = Builders<Product>.Filter.Eq("name", name);
            return (Interface_Mongo_Http.IProduct)_db.GetCollection<Product>("products").Find(filter).FirstOrDefault();
        }

        public void Create(IProduct p)
        {
            var product = new Product{
                Id = ObjectId.GenerateNewId(),
                Name = p.Name,
                MachineId = p.MachineId,
                CurrentStock = p.CurrentStock,
                MaxStock = p.MaxStock,
                Category = p.Category
            };


            _db.GetCollection<Product>("products").InsertOne(product);
        }

        public void Update(string name, IProduct p)
        {
            /*var filter = Builders<Product>.Filter.Eq("name", name);
            var product = new Product
            {
                Id = ObjectId.GenerateNewId(),
                Name = p.Name,
                MachineId = p.MachineId,
                CurrentStock = p.CurrentStock,
                MaxStock = p.MaxStock,
                Category = p.Category
            };
            _db.GetCollection<Product>("products").ReplaceOne(filter, product);*/
            var filter = Builders<Product>.Filter.Eq("name", name);
            var update = Builders<Product>.Update
                .Set("name", p.Name)
                .Set("machine_id", p.MachineId)
                .Set("current_stock", p.CurrentStock)
                .Set("max_stock", p.MaxStock)
                .Set("category", p.Category);
            
            _db.GetCollection<Product>("products").UpdateOne(filter, update);
        }
        public void Remove(string name)
        {
            var filter = Builders<Product>.Filter.Eq("name", name);
            _db.GetCollection<Product>("products").DeleteOne(filter);
        }
    }
}