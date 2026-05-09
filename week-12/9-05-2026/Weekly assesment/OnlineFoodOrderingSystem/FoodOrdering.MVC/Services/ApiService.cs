using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FoodOrdering.MVC.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        private readonly IHttpContextAccessor
            _httpContextAccessor;

        public ApiService(
            HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;

            _httpContextAccessor =
                httpContextAccessor;
        }

        private void AddJwtToken()
        {
            var token =
                _httpContextAccessor
                .HttpContext?
                .Session
                .GetString("JWToken");

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient
                    .DefaultRequestHeaders
                    .Authorization =
                    new AuthenticationHeaderValue(
                        "Bearer",
                        token);
            }
        }

        public async Task<T?> GetAsync<T>(
            string url)
        {
            AddJwtToken();

            var response =
                await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return default;

            var json =
                await response.Content
                    .ReadAsStringAsync();

            return JsonConvert
                .DeserializeObject<T>(json);
        }

        public async Task<List<T>?> GetListAsync<T>(
            string url)
        {
            AddJwtToken();

            var response =
                await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return default;

            var json =
                await response.Content
                    .ReadAsStringAsync();

            return JsonConvert
                .DeserializeObject<List<T>>(json);
        }

        public async Task<bool> PostAsync(
            string url,
            object data)
        {
            AddJwtToken();

            var json =
                JsonConvert.SerializeObject(data);

            var content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            var response =
                await _httpClient.PostAsync(
                    url,
                    content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(
            string url,
            object data)
        {
            AddJwtToken();

            var json =
                JsonConvert.SerializeObject(data);

            var content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            var response =
                await _httpClient.PutAsync(
                    url,
                    content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(
            string url)
        {
            AddJwtToken();

            var response =
                await _httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }
}