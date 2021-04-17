using System;
using System.Collections.Generic;

#nullable disable

namespace EstoreAPI.Models
{
    public partial class TProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public string Src { get; set; }

        public virtual TProduct Product { get; set; }
    }
}
