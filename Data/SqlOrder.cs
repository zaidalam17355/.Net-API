using EstoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Data
{
    public class SqlOrder : IOrder
    {
        private readonly pocContext _context;
        public SqlOrder(pocContext pocContext)
        {
            _context = pocContext;
        }
        public void AddOrder(TOrder order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            var item = _context.TProducts.FirstOrDefault(x => x.Id == order.Id);
            order.OrderTotal = item.Price;

            _context.TOrders.Add(order);
            _context.SaveChanges();
        }

        public IEnumerable<TOrder> Orders()
        {
            return _context.TOrders.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
