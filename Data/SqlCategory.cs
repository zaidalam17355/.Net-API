using EstoreAPI.Data;
using EstoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Data
{
    public class SqlCategory : ICategory
    {
        private readonly pocContext _context;

        public SqlCategory(pocContext pocContext)
        {
            _context = pocContext;
        }
        public void CreateCategory(TCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            _context.TCategories.Add(category);
            _context.SaveChanges();
        }

        public IEnumerable<TCategory> GetAllCategories()
        {
            return _context.TCategories.ToList();
        }

        public TCategory GetCategoryById(int id)
        {
            return _context.TCategories.FirstOrDefault(x => x.CategoryId == id);

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
