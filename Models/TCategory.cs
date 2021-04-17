using System;
using System.Collections.Generic;

#nullable disable

namespace EstoreAPI.Models
{
    public partial class TCategory
    {
        public string CategoryName { get; set; }
        public int? IconId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public virtual TProduct Product { get; set; }
    }
}
