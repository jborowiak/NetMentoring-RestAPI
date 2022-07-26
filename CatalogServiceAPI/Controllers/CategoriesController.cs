using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using CatalogServiceAPI.Models;

namespace CatalogServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CategoryGet>> GetCategories()
        {
            return Ok(new List<CategoryGet>()
            {
                new CategoryGet(1, "test1", "anc"),
                new CategoryGet(2, "test2", "anc")
            });
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryAdd category)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromRoute] int id, [FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            var categoryUpdate = new CategoryUpdate(id, categoryUpdateDto.Name, categoryUpdateDto.Description);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            return Ok();
        }
    }
}
