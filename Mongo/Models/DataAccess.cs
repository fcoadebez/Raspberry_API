using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;

namespace MVC6_WEBAPI_MongoDB.Models
{
    public class DataAccess
    {
        MongoClient _client;
        IMongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("ecv-app-iot:ecv123@ds237808.mlab.com:37808/app-iot");
            _db = _client.GetDatabase("Products");
        }

        public IEnumerable<Product> GetProducts()
        {
            return _db.GetCollection<Product>("Products").AsQueryable<Product>().ToList();

        }

        public Product GetProduct(ObjectId id)
        {
            /*var res = Query<Product>.EQ(p => p.Id, id);
            return _db.GetCollection<Product>("Products").FindOne();*/
            var filter = Builders<Product>.Filter.Eq("i", id);
            return _db.GetCollection<Product>("Products").Find(filter).FirstOrDefault();
        }

        //public Product Create(Product p)
        //{
        //    /*_db.GetCollection<Product>("Products").Save(p);
        //    return p;*/
        //    //return _db.GetCollection<Product>("Products").AsQueryable<Product>().ToList();
        //}

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
