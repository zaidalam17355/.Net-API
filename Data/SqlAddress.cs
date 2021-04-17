using EstoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Data
{
    public class SqlAddress : IAddress
    {
        private readonly pocContext _context;
        public SqlAddress(pocContext pocContext)
        {
            _context = pocContext;
        }
        public void CreateAddress(TAddress address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            _context.TAddresses.Add(address);
            _context.SaveChanges();
        }

        public void DeleteAddress(TAddress address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            _context.TAddresses.Remove(address);
        }

        public IEnumerable<TAddress> GetAddress()
        {
            return _context.TAddresses.ToList();
        }

        public TAddress GetAddressByPhoneNo(string phoneno)
        {
            return _context.TAddresses.FirstOrDefault(x => x.PhoneNo == phoneno);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
