using EstoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Data
{
    public interface ICategory
    {
        bool SaveChanges();

        IEnumerable<TCategory> GetAllCategories();
        TCategory GetCategoryById(int id);
        void CreateCategory(TCategory category);
    }
}
