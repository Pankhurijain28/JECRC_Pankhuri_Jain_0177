using FoodOrdering.API.Data;
using FoodOrdering.API.DTOs;
using FoodOrdering.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FoodItemsController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var foodItems =
                await _context.FoodItems
                    .Include(f => f.Category)
                    .ToListAsync();

            return Ok(foodItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var foodItem =
                await _context.FoodItems
                    .Include(f => f.Category)
                    .FirstOrDefaultAsync(
                        f => f.Id == id);

            if (foodItem == null)
                return NotFound();

            return Ok(foodItem);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(
            FoodItemDto model)
        {
            var foodItem = new FoodItem
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            };

            _context.FoodItems.Add(foodItem);

            await _context.SaveChangesAsync();

            return Ok(foodItem);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            FoodItemDto model)
        {
            var foodItem =
                await _context.FoodItems.FindAsync(id);

            if (foodItem == null)
                return NotFound();

            foodItem.Name = model.Name;
            foodItem.Description = model.Description;
            foodItem.Price = model.Price;
            foodItem.ImageUrl = model.ImageUrl;
            foodItem.CategoryId = model.CategoryId;

            await _context.SaveChangesAsync();

            return Ok(foodItem);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var foodItem =
                await _context.FoodItems.FindAsync(id);

            if (foodItem == null)
                return NotFound();

            _context.FoodItems.Remove(foodItem);

            await _context.SaveChangesAsync();

            return Ok(
                "Food item deleted successfully.");
        }
    }
}