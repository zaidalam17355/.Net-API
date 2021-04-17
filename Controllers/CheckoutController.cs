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
    [Route("api/checkout")]
    public class CheckoutController:ControllerBase
    {
        private readonly ICheckout _checkout;

        public CheckoutController(ICheckout checkout)
        {
            _checkout = checkout;
        }

        [HttpGet("{id}")]
        public ActionResult<TCheckout> GetPaymentById(int id)
        {
            var item = _checkout.GetPaymentById(id);

            if (item != null)
                return Ok(item);

            return NotFound();
        }

        [HttpPost]
        public ActionResult<TCheckout> Post(TCheckout payment)
        {
            _checkout.CreatePayment(payment);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<TCheckout> Delete(int id)
        {
            var paymentObject = _checkout.GetPaymentById(id);
            if (paymentObject == null)
                return NotFound();

            _checkout.DeletePayment(paymentObject);
            _checkout.SaveChanges();

            return NoContent();
        }
    }
}
