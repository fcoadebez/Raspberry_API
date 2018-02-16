using System;
using System.Collections.Generic;
using System.Linq;
using Interface_Mongo_Http;

namespace Raspberry_API.Tests
{
    public class TestInterface : Interface
    {
        List<string> products = new List<string>(new string[] { "element1", "element2", "element3" });

        public TestInterface()
        {

        }

        public List<Product> GetProducts()
        {
            return products.Select(p => new Product { Nom = p }).ToList();
        }


    }
}
