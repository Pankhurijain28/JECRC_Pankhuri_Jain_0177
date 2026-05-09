namespace FoodOrdering.MVC.ViewModels
{
    public class InvoiceViewModel
    {
        public int OrderId { get; set; }

        public string CustomerName { get; set; }
            = string.Empty;

        public string CustomerEmail { get; set; }
            = string.Empty;

        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderItemViewModel> Items
        { get; set; } = new();
    }
}