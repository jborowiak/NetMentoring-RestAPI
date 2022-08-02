using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using CatalogServiceAPI.Infrastructure;
using CatalogServiceAPI.Models;

namespace CatalogServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICatalogDbContext _dbContext;

        public CategoriesController(ICatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryGet>> GetCategories()
        {
            var categories = _dbContext.Categories.Select(x => new CategoryGet(x.Id, x.Name, x.Description));

            return Ok(categories);
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryAdd category)
        {
            var existingCategories = _dbContext.Categories.Select(x => new CategoryGet(x.Id, x.Name, x.Description));
            if (existingCategories.Any(x => x.Name == category.Name))
            {
                return BadRequest("Category with this name already exists");
            }

            _dbContext.Categories.Add(new Category()
            {
                Name = category.Name,
                Description = category.Description
            });
            _dbContext.SaveAsync();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromRoute] int id, [FromBody] CategoryUpdate categoryUpdateDto)
        {
            //var categoryUpdate = new CategoryUpdate(id, categoryUpdateDto.Name, categoryUpdateDto.Description);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            return Ok();
        }
    }
}
