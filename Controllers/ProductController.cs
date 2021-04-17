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
    [Route("api/product")]
    public class ProductController:ControllerBase
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TProduct>> Get()
        {
            var items = _product.GetAllProduct();
            return Ok(items);
        }

        [HttpPost]
        public ActionResult<TUser> Post(TProduct product)
        {
            _product.CreateProduct(product);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<TProduct> GetProductById(int id)
        {
            var item = _product.GetProductById(id);

            if (item != null)
                return Ok(item);

            return NotFound();
        }

        [HttpGet("find/{type}")]
        public ActionResult<IEnumerable<TProduct>> GetByCategory(string type)
        {
            var items = _product.GetProductByProductType(type);
            return Ok(items);
        }


    }
}
