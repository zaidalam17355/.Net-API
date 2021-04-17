using EstoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Data
{
    public class SqlUser : IUser
    {
        private readonly pocContext _context;

        public SqlUser(pocContext pocContext)
        {
            _context = pocContext;

        }
        public void CreateUser(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.TUsers.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.TUsers.Remove(user);
        }

        public IEnumerable<TUser> GetAllUser()
        {
            return _context.TUsers.ToList();
        }

        public TUser GetUserByEmail(string email)
        {
            return _context.TUsers.FirstOrDefault(x => x.Email == email);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
