using System;
using System.Collections.Generic;

#nullable disable

namespace EstoreAPI.Models
{
    public partial class TUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }

        public virtual TAddress Address { get; set; }
    }
}
