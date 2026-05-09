namespace FoodOrdering.MVC.ViewModels
{
    public class OrderCreateDto
    {
        public string CustomerName { get; set; }
            = string.Empty;

        public string CustomerEmail { get; set; }
            = string.Empty;

        public List<OrderItemCreateDto> OrderItems
        { get; set; } = new();
    }
}