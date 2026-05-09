using FoodOrdering.MVC.Services;
using FoodOrdering.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FoodOrdering.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApiService _apiService;

        public AdminController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Orders()
        {
            var orders =
                await _apiService.GetAsync
                <List<OrderViewModel>>(
                    "api/Orders");

            return View(orders);
        }

        public async Task<IActionResult> Foods(
            string? search)
        {
            var foods =
                await _apiService.GetListAsync
                <FoodItemViewModel>(
                    "api/FoodItems");

            if (!string.IsNullOrWhiteSpace(search))
            {
                foods = foods?
                    .Where(x =>
                        x.Name.Contains(
                            search,
                            StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(foods);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(
            CategoryViewModel model)
        {
            await _apiService.PostAsync(
                "api/Categories",
                model);

            return RedirectToAction("Foods");
        }

        [HttpGet]
        public async Task<IActionResult> CreateFood()
        {
            var categories =
                await _apiService.GetListAsync
                <dynamic>("api/Categories");

            var model =
                new FoodCreateViewModel();

            if (categories != null)
            {
                model.Categories =
                    categories.Select(c =>
                        new SelectListItem
                        {
                            Text = c.name.ToString(),
                            Value = c.id.ToString()
                        }).ToList();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood(
            FoodCreateViewModel model)
        {
            if (model.ImageFile == null)
                return View(model);

            using var content =
                new MultipartFormDataContent();

            using var fileStream =
                model.ImageFile.OpenReadStream();

            content.Add(
                new StreamContent(fileStream),
                "File",
                model.ImageFile.FileName);

            var client = new HttpClient();

            var uploadResponse =
                await client.PostAsync(
                    "http://localhost:5187/api/Upload",
                    content);

            var uploadJson =
                await uploadResponse.Content
                    .ReadAsStringAsync();

            dynamic? uploadResult =
                JsonConvert.DeserializeObject(uploadJson);

            string imageUrl =
                uploadResult?.imageUrl;

            var foodDto =
                new FoodItemDto
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId,
                    ImageUrl = imageUrl
                };

            await _apiService.PostAsync(
                "api/FoodItems",
                foodDto);

            return RedirectToAction("Foods");
        }

        [HttpGet]
        public async Task<IActionResult> EditFood(
            int id)
        {
            var food =
                await _apiService.GetAsync
                <FoodItemViewModel>(
                    $"api/FoodItems/{id}");

            var categories =
                await _apiService.GetListAsync
                <dynamic>("api/Categories");

            var model =
                new FoodCreateViewModel
                {
                    Name = food!.Name,
                    Description = food.Description,
                    Price = food.Price,
                    CategoryId = food.CategoryId
                };

            if (categories != null)
            {
                model.Categories =
                    categories.Select(c =>
                        new SelectListItem
                        {
                            Text = c.name.ToString(),
                            Value = c.id.ToString()
                        }).ToList();
            }

            ViewBag.FoodId = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditFood(
            int id,
            FoodCreateViewModel model)
        {
            string imageUrl = "";

            if (model.ImageFile != null)
            {
                using var content =
                    new MultipartFormDataContent();

                using var fileStream =
                    model.ImageFile.OpenReadStream();

                content.Add(
                    new StreamContent(fileStream),
                    "File",
                    model.ImageFile.FileName);

                var client = new HttpClient();

                var uploadResponse =
                    await client.PostAsync(
                        "http://localhost:5187/api/Upload",
                        content);

                var uploadJson =
                    await uploadResponse.Content
                        .ReadAsStringAsync();

                dynamic? uploadResult =
                    JsonConvert.DeserializeObject(uploadJson);

                imageUrl =
                    uploadResult?.imageUrl;
            }

            var foodDto =
                new FoodItemDto
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId,
                    ImageUrl = imageUrl
                };

            await _apiService.PutAsync(
                $"api/FoodItems/{id}",
                foodDto);

            return RedirectToAction("Foods");
        }

        public async Task<IActionResult> DeleteFood(
            int id)
        {
            await _apiService.DeleteAsync(
                $"api/FoodItems/{id}");

            return RedirectToAction("Foods");
        }
    }
}