using System;
using System.Collections.Generic;

namespace Interface_Mongo_Http
{
    public interface Interface
    {
        List<Product> GetProducts();

        Product getProduct(int id);
    }
}
