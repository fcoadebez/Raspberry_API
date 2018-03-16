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
            _client = new MongoClient("mongodb://readonly:ecv123@ds237808.mlab.com:37808/app-iot");
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
            _db.GetCollection<IProduct>("Products").InsertOne(p);
        }

        public void Update(string name, Product p)
        {
            /*var filter = Builders<Product>.Filter.Eq("name", name);
+            var updateDefinition = Builders<Product>.Update.Set();
+            _db.GetCollection<Product>("Products").UpdateOne();*/
        }
        public void Remove(string name)
        {
            var filter = Builders<Product>.Filter.Eq("name", name);
            _db.GetCollection<Product>("Products").DeleteOne(filter);
        }
    }
}