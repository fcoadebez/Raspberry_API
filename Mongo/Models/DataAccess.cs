using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using Interface_Mongo_Http;

namespace Mongo
{
    public class DataAccess :Interface
    {
        MongoClient _client;
        IMongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("ecv-app-iot:ecv123@ds237808.mlab.com:37808/app-iot");
            _db = _client.GetDatabase("Products");
        }

        public IEnumerable<IProduct> GetProducts()
        {
            return _db.GetCollection<IProduct>("Products").AsQueryable<IProduct>().ToList();

        }

        public IProduct GetProduct(ObjectId id)
        {
            /*var res = Query<Product>.EQ(p => p.Id, id);
            return _db.GetCollection<Product>("Products").FindOne();*/
            var filter = Builders<IProduct>.Filter.Eq("i", id);
            return _db.GetCollection<IProduct>("Products").Find(filter).FirstOrDefault();
        }

        public string Create(IProduct p)
        {
            _db.GetCollection<IProduct>("Products").InsertOne(p);

            return "Ok";
        }

        public void Update(string name, IProduct p)
        {
            /*var filter = Builders<Product>.Filter.Eq("name", name);
            var updateDefinition = Builders<Product>.Update.Set();
            _db.GetCollection<Product>("Products").UpdateOne();*/
        }
        public void Remove(string name)
        {
            var filter = Builders<IProduct>.Filter.Eq("name", name);
            _db.GetCollection<IProduct>("Products").DeleteOne(filter);
        }

        List<IProduct> Interface.GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public IProduct GetProduct(string name)
        {
            throw new System.NotImplementedException();
        }

        IProduct Interface.Create(IProduct p)
        {
            throw new System.NotImplementedException();
        }
    }
}
