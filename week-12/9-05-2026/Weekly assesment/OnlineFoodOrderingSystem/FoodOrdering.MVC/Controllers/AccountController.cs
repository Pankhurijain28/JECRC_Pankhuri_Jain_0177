using FoodOrdering.MVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace FoodOrdering.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController()
        {
            _httpClient = new HttpClient();

            _httpClient.BaseAddress =
                new Uri("http://localhost:5187/");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(
            LoginViewModel model)
        {
            var json =
                JsonConvert.SerializeObject(model);

            var content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            var response =
                await _httpClient.PostAsync(
                    "api/Auth/login",
                    content);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error =
                    "Invalid login credentials";

                return View(model);
            }

            var responseJson =
                await response.Content
                    .ReadAsStringAsync();

            var authResult =
                JsonConvert.DeserializeObject
                <AuthResponseViewModel>(
                    responseJson);

            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.Name,
                    model.Email)
            };

            foreach (var role in authResult!.Roles)
            {
                claims.Add(
                    new Claim(
                        ClaimTypes.Role,
                        role));
            }

            var identity =
                new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults
                        .AuthenticationScheme);

            var principal =
                new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults
                    .AuthenticationScheme,
                principal);

            HttpContext.Session.SetString(
                "JWToken",
                authResult.Token);

            return RedirectToAction(
                "Index",
                "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(
            RegisterViewModel model)
        {
            var json =
                JsonConvert.SerializeObject(model);

            var content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            var response =
                await _httpClient.PostAsync(
                    "api/Auth/register",
                    content);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error =
                    "Registration failed";

                return View(model);
            }

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();

            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults
                    .AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}