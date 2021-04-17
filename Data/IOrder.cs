using EstoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Data
{
    public interface IOrder
    {
        bool SaveChanges();
        IEnumerable<TOrder> Orders();
        void AddOrder(TOrder order);
    }
}
