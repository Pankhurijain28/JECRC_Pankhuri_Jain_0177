using FoodOrdering.MVC.Services;
using FoodOrdering.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodOrdering.MVC.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApiService _apiService;

        public CartController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            var cartJson =
                HttpContext.Session
                    .GetString("Cart");

            var cart =
                string.IsNullOrEmpty(cartJson)
                ? new List<CartItemViewModel>()
                : JsonConvert.DeserializeObject
                    <List<CartItemViewModel>>(cartJson);

            return View(cart);
        }

        public async Task<IActionResult> AddToCart(
            int id)
        {
            var food =
                await _apiService.GetAsync
                <FoodItemViewModel>(
                    $"api/FoodItems/{id}");

            if (food == null)
                return RedirectToAction(
                    "Index",
                    "Home");

            var cartJson =
                HttpContext.Session
                    .GetString("Cart");

            var cart =
                string.IsNullOrEmpty(cartJson)
                ? new List<CartItemViewModel>()
                : JsonConvert.DeserializeObject
                    <List<CartItemViewModel>>(cartJson);

            var existingItem =
                cart!.FirstOrDefault(
                    x => x.FoodItemId == id);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(
                    new CartItemViewModel
                    {
                        FoodItemId = food.Id,
                        Name = food.Name,
                        Price = food.Price,
                        Quantity = 1,
                        ImageUrl = food.ImageUrl
                    });
            }

            HttpContext.Session.SetString(
                "Cart",
                JsonConvert.SerializeObject(cart));

            return RedirectToAction("Index");
        }

        public IActionResult Remove(
            int id)
        {
            var cartJson =
                HttpContext.Session
                    .GetString("Cart");

            var cart =
                string.IsNullOrEmpty(cartJson)
                ? new List<CartItemViewModel>()
                : JsonConvert.DeserializeObject
                    <List<CartItemViewModel>>(cartJson);

            var item =
                cart?.FirstOrDefault(
                    x => x.FoodItemId == id);

            if (item != null)
            {
                cart!.Remove(item);
            }

            HttpContext.Session.SetString(
                "Cart",
                JsonConvert.SerializeObject(cart));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Checkout()
        {
            var cartJson =
                HttpContext.Session
                    .GetString("Cart");

            var cart =
                string.IsNullOrEmpty(cartJson)
                ? new List<CartItemViewModel>()
                : JsonConvert.DeserializeObject
                    <List<CartItemViewModel>>(cartJson);

            if (cart == null || !cart.Any())
                return RedirectToAction("Index");

            var order =
                new OrderCreateDto
                {
                    CustomerName =
                        User.Identity?.Name
                        ?? "Customer",

                    CustomerEmail =
                        User.Identity?.Name
                        ?? "customer@test.com",

                    OrderItems =
                        cart.Select(x =>
                            new OrderItemCreateDto
                            {
                                FoodItemId =
                                    x.FoodItemId,

                                Quantity =
                                    x.Quantity
                            }).ToList()
                };

            await _apiService.PostAsync(
                "api/Orders",
                order);

            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}