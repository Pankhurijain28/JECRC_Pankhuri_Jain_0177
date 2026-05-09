namespace FoodOrdering.MVC.ViewModels
{
    public class OrderItemViewModel
    {
        public string FoodName { get; set; }
            = string.Empty;

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}