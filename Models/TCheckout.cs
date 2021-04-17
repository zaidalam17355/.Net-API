using System;
using System.Collections.Generic;

#nullable disable

namespace EstoreAPI.Models
{
    public partial class TCheckout
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? AddressId { get; set; }
        public string CardNo { get; set; }
        public short? ValidFrom { get; set; }
        public short? ValidTo { get; set; }
        public short? Cvv { get; set; }
        public string HolderName { get; set; }
        public int? UserId { get; set; }

        public virtual TAddress Address { get; set; }
        public virtual TOrder Order { get; set; }
    }
}
