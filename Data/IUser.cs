using EstoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Data
{
    public interface IUser
    {
        bool SaveChanges();
        IEnumerable<TUser> GetAllUser();
        TUser GetUserByEmail(string email);
        void CreateUser(TUser user);
        void DeleteUser(TUser user);
    }
}
