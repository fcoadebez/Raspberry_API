using System;
using System.Collections.Generic;

namespace Interface_Mongo_Http
{
    public interface Interface
    {
        List<IProduct> GetProducts();

        IProduct GetProduct(string name);

        void Create(IProduct p);
        void Update(string name, IProduct p);
        void Remove(string name);

    }
}
