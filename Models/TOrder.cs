using System;
using System.Collections.Generic;

#nullable disable

namespace EstoreAPI.Models
{
    public partial class TOrder
    {
        public TOrder()
        {
            TCheckouts = new HashSet<TCheckout>();
        }

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public decimal? OrderTotal { get; set; }

        public virtual TProduct Product { get; set; }
        public virtual ICollection<TCheckout> TCheckouts { get; set; }
    }
}
