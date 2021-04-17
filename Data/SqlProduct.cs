using EstoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Data
{
    
        public class SqlProduct : IProduct
        {
            private readonly pocContext _context;
            public SqlProduct(pocContext pocContext)
            {
                _context = pocContext;
            }

        public void CreateProduct(TProduct product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _context.TProducts.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(TProduct product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _context.TProducts.Remove(product);
        }

        public IEnumerable<TProduct> GetAllProduct()
        {
            return _context.TProducts.ToList();
        }

        public TProduct GetProductById(int id)
        {
            return _context.TProducts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TProduct> GetProductByProductType(string type)
        {
            return _context.TProducts.Where(x => x.ProductType == type).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
