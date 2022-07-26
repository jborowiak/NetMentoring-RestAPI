using System.Collections.Generic;
using CatalogServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<ItemGet>> GetItems()
        {
            return Ok(new List<ItemGet>()
            {
                new ItemGet(1, "test1", new CategoryGet(1, "test", "test")),
                new ItemGet(2, "test2", new CategoryGet(1, "test", "test"))
            });
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] ItemAdd item)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem([FromRoute] int id, [FromBody] ItemUpdateDto itemUpdateDto)
        {
            var itemUpdate = new ItemUpdate(id, itemUpdateDto.Name, itemUpdateDto.CategoryId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem([FromRoute] int id)
        {
            return Ok();
        }
    }
}