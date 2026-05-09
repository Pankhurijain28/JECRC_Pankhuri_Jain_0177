using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodOrdering.MVC.ViewModels
{
    public class FoodCreateViewModel
    {
        public string Name { get; set; }
            = string.Empty;

        public string Description { get; set; }
            = string.Empty;

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public IFormFile? ImageFile { get; set; }

        public List<SelectListItem> Categories
        { get; set; } = new();
    }
}