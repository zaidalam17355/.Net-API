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
    [Route("api/address")]
    public class AddressController:ControllerBase
    {
        private readonly IAddress _address;
        public AddressController(IAddress address)
        {
            _address = address;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TAddress>> GetAllCustomer()
        {
            var items = _address.GetAddress();
            return Ok(items);
        }

        [HttpGet("{phoneno}")]
        public ActionResult<TAddress> GetAddressByPhoneno(string phoneno)
        {
            var addressFromPhone = _address.GetAddressByPhoneNo(phoneno);
            if (addressFromPhone == null)
                return NotFound();

            return Ok(addressFromPhone);
        }

        [HttpPost]
        public ActionResult<TAddress> Post(TAddress address)
        {
            _address.CreateAddress(address);
            return Ok();
        }

        [HttpDelete("{phoneno}")]
        public ActionResult Delete(string phoneno)
        {
            var item = _address.GetAddressByPhoneNo(phoneno);
            if (item == null)
                return NotFound();

            _address.DeleteAddress(item);
            _address.SaveChanges();
            return Ok();

        }
    }
}
