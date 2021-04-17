using EstoreAPI.Data;
using EstoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoreAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController:ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TUser>> GetAllUser()
        {
            var items = _user.GetAllUser();
            return Ok(items);
        }

        [HttpGet("{email}", Name = "getByEmail")]
        public ActionResult<TUser> GetUserByEmail(string email)
        {
            var item = _user.GetUserByEmail(email);

            if (item != null)
                return Ok(item);

            return NotFound();
        }

        [HttpPost]
        public ActionResult<TUser> Post(TUser user)
        {
            _user.CreateUser(user);
            return Ok();
        }

        [HttpDelete("{email}")]
        public ActionResult<TUser> Delete(string email)
        {
            var customerObject = _user.GetUserByEmail(email);
            if (customerObject == null)
                return NotFound();

            _user.DeleteUser(customerObject);
            _user.SaveChanges();

            return Ok();


        }


    }
}
