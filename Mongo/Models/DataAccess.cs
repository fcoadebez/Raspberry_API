using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Diagnostics;
using Interface_Mongo_Http;
using System.Linq;

namespace Mongo
{
    public class DataAccess :Interface
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

        public ObjectId Create(Product p)
        {
            /*_db.GetCollection<Product>("Products").Save(p);
            return p;*/
            //return _db.GetCollection<Product>("Products").AsQueryable<Product>().ToList();
            return p.Id;
        }

        public void Update(ObjectId id, Product p)
        {
            /*p.Id = id;
            var res = Query<Product>.EQ(pd => pd.Id, id);
            var operation = Update<Product>.Replace(p);
            _db.GetCollection<Product>("Products").Update(res, operation);*/
            //return _db.GetCollection<Product>("Products").AsQueryable<Product>().ToList();

        }
        public void Remove(ObjectId id)
        {
            /*var res = Query<Product>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Product>("Products").Remove(res);*/
            //return _db.GetCollection<Product>("Products").AsQueryable<Product>().ToList();
        }
    }
}
