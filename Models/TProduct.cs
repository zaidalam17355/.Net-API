using System;
using System.Collections.Generic;

#nullable disable

namespace EstoreAPI.Models
{
    public partial class TProduct
    {
        public TProduct()
        {
            TCategories = new HashSet<TCategory>();
            TOrders = new HashSet<TOrder>();
            TProductImages = new HashSet<TProductImage>();
            TSubCategories = new HashSet<TSubCategory>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<TCategory> TCategories { get; set; }
        public virtual ICollection<TOrder> TOrders { get; set; }
        public virtual ICollection<TProductImage> TProductImages { get; set; }
        public virtual ICollection<TSubCategory> TSubCategories { get; set; }
    }
}
