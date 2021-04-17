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
    [Route("product/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }

        [HttpPost]
        public ActionResult<TCategory> Post(TCategory category)
        {
            _category.CreateCategory(category);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<TCategory> GetById(int id)
        {
            var item = _category.GetCategoryById(id);
            if (item == null)
                return NotFound();
            else
                return Ok(item);
        }

    }
}
