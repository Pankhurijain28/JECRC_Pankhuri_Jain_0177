using FoodOrdering.MVC.Services;
using FoodOrdering.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApiService _apiService;

        public HomeController(
            ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var foods =
                await _apiService.GetAsync
                <List<FoodItemViewModel>>(
                    "api/FoodItems");

            return View(foods);
        }
    }
}