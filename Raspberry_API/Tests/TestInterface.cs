using System;
using System.Collections.Generic;
using System.Linq;
using Interface_Mongo_Http;

namespace Raspberry_API.Tests
{
    public class TestProduct :IProduct
    {

        public string MachineId { get; set; }

        public string Name { get; set; }

        public int CurrentStock { get; set; }

        public int MaxStock { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

    }
    public class TestInterface : Interface
    {
        List<string> products = new List<string>(new string[] { "element1", "element2", "element3", "element4" });

        public TestInterface()
        {

        }

        public IProduct GetProduct(string name)
        {
            throw new NotImplementedException();
        }

        public List<IProduct> GetProducts()
        {
            return products.Select(p => (IProduct) new TestProduct { Name = p }).ToList();
        }
        public void Create(IProduct p)
        {
        }
        public void Update(string name, IProduct p)
        {
        }
        public void Remove(IProduct p)
        {
        }

    }
}
