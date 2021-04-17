using System;
using System.Collections.Generic;

#nullable disable

namespace EstoreAPI.Models
{
    public partial class TAddress
    {
        public TAddress()
        {
            TCheckouts = new HashSet<TCheckout>();
            TUsers = new HashSet<TUser>();
        }

        public int UserId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Pincode { get; set; }
        public string PhoneNo { get; set; }

        public virtual ICollection<TCheckout> TCheckouts { get; set; }
        public virtual ICollection<TUser> TUsers { get; set; }
    }
}
