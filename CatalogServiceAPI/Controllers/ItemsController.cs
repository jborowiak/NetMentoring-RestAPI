﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogServiceAPI.Infrastructure;
using CatalogServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : Controller
    {
        private readonly ICatalogDbContext _dbContext;

        public ItemsController(ICatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemGet>> GetItems()
        {
            var items = _dbContext.Items.Select(x => new ItemGet(x.Id, x.Name, new CategoryGet(x.CategoryId, x.Category.Name, x.Category.Description)));

            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemAdd item)
        {
            var existingItems = _dbContext.Items.Select(x => new ItemGet(x.Id, x.Name, new CategoryGet(x.CategoryId, x.Category.Name, x.Category.Description)));
            if (existingItems.Any(x => x.Name == item.Name))
            {
                return BadRequest("Item with this name already exists");
            }

            _dbContext.Items.Add(new Item()
            {
                Name = item.Name,
                CategoryId = item.CategoryId
            });
            await _dbContext.SaveAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem([FromRoute] int id, [FromBody] ItemUpdate itemUpdateDto)
        {
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound("Item does not exist");
            }

            item.Name = itemUpdateDto.Name;
            item.CategoryId = itemUpdateDto.CategoryId;

            await _dbContext.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound("Item does not exist");
            }

            _dbContext.Items.Remove(item);
            await _dbContext.SaveAsync();

            return Ok();
        }
    }
}