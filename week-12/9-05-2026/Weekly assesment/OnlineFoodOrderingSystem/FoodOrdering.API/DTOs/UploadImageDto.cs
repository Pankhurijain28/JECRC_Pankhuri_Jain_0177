using Microsoft.AspNetCore.Http;

namespace FoodOrdering.API.DTOs
{
    public class UploadImageDto
    {
        public IFormFile File { get; set; }
    }
}