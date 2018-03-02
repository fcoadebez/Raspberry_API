using System;
using System.Collections.Generic;

namespace Interface_Mongo_Http
{
    public interface Interface
    {
        List<IProduct> GetProducts();

        IProduct GetProduct(string name);
    }
}
