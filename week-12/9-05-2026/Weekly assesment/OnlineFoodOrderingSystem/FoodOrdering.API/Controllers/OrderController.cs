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
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(
            CreateOrderDto model)
        {
            var order = new Order
            {
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                TotalAmount = model.TotalAmount,
                OrderDate = DateTime.Now,
                Status = "Pending"
            };

            foreach (var item in model.Items)
            {
                order.OrderItems.Add(
                    new OrderItem
                    {
                        FoodItemId = item.FoodItemId,
                        FoodName = item.FoodName,
                        Price = item.Price,
                        Quantity = item.Quantity
                    });
            }

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message =
                    "Order placed successfully",

                orderId = order.Id
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders =
                await _context.Orders
                    .Include(x => x.OrderItems)
                    .OrderByDescending(
                        x => x.OrderDate)
                    .ToListAsync();

            return Ok(orders);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(
            int id,
            UpdateOrderStatusDto model)
        {
            var order =
                await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            order.Status = model.Status;

            await _context.SaveChangesAsync();

            return Ok(order);
        }
    }
}