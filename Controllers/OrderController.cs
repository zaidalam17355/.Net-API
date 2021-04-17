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
    [Route("api/order")]
    public class OrderController:ControllerBase
    {
        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TOrder>> GetAllOrder()
        {
            var items = _order.Orders();
            return Ok(items);
        }

        [HttpPost]
        public ActionResult<TOrder> Post(TOrder order)
        {
            _order.AddOrder(order);
            return Ok();
        }

    }
}
