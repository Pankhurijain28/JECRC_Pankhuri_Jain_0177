namespace FoodOrdering.MVC.ViewModels
{
    public class CartItemViewModel
    {
        public int FoodItemId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public int Quantity { get; set; }
    }
}