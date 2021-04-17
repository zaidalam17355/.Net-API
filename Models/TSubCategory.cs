using System;
using System.Collections.Generic;

#nullable disable

namespace EstoreAPI.Models
{
    public partial class TSubCategory
    {
        public int Id { get; set; }
        public string SubCatName { get; set; }
        public int? ProductId { get; set; }

        public virtual TProduct Product { get; set; }
    }
}
