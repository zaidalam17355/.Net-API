using EstoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Data
{
    public interface IProduct
    {
        bool SaveChanges();
        IEnumerable<TProduct> GetAllProduct();
        TProduct GetProductById(int id);
        IEnumerable<TProduct> GetProductByProductType(string type);
        void CreateProduct(TProduct product);
        void DeleteProduct(TProduct product);
    }
}
