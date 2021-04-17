using EstoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Data
{
    public class SqlCheckout : ICheckout
    {
        private readonly pocContext _context;
        public SqlCheckout(pocContext pocContext)
        {
            _context = pocContext;

        }
        public void CreatePayment(TCheckout checkout)
        {
            if (checkout == null)
                throw new ArgumentNullException(nameof(checkout));

            _context.TCheckouts.Add(checkout);
            _context.SaveChanges();
        }

        public void DeletePayment(TCheckout checkout)
        {
            if (checkout == null)
                throw new ArgumentNullException(nameof(checkout));

            _context.TCheckouts.Remove(checkout);
        }

        public TCheckout GetPaymentById(int id)
        {
            return _context.TCheckouts.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
