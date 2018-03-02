using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using Mongo;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestQueryOne()
        {
            string name = "A12";
            DataAccess dataAccess = new DataAccess();
            var test = dataAccess.GetProduct(name);
            Assert.IsTrue(test != null);
        }

        [TestMethod]
        public void TestQueryAll()
        {
            DataAccess dataAccess = new DataAccess();
            var test = dataAccess.GetProducts();
            Assert.IsTrue(test != null);
        }
    }
}
