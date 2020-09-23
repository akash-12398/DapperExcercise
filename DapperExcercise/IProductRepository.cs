using System;
using System.Collections.Generic;

namespace DapperExcercise
{
    public interface IProductRepository
    {
        
        
            IEnumerable<Product> GetAllProducts(); 
        
    }
}
