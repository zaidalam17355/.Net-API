using EstoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Data
{
    public interface IAddress
    {
        bool SaveChanges();

        IEnumerable <TAddress> GetAddress();
        TAddress GetAddressByPhoneNo(string phoneno);
        void CreateAddress(TAddress address);
        void DeleteAddress(TAddress address);
    }
}
