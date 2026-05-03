using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using EMS.MVC.Models;

namespace EMS.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _httpClient;

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            var json = JsonSerializer.Serialize(emp);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/employees", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/employees/{id}");
            return RedirectToAction("Index");
        }

        public EmployeeController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("api");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/employees");

                if (!response.IsSuccessStatusCode)
                {
                    return Content("API call failed: " + response.StatusCode);
                }

                var json = await response.Content.ReadAsStringAsync();

                var employees = JsonSerializer.Deserialize<List<Employee>>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Employee>();

                return View(employees);
            }
            catch (Exception ex)
            {
                return Content("Error: " + ex.Message);
            }

        }
    }
}