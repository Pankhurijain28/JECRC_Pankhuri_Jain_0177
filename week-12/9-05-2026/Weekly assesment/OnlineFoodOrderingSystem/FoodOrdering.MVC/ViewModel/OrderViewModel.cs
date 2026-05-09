namespace FoodOrdering.MVC.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }
            = string.Empty;

        public string CustomerEmail { get; set; }
            = string.Empty;

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }
            = string.Empty;

        public DateTime OrderDate { get; set; }

        public List<OrderItemViewModel> OrderItems
        { get; set; } = new();
    }
}