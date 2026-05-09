namespace FoodOrdering.API.DTOs
{
    public class CreateOrderDto
    {
        public string CustomerName { get; set; } = string.Empty;

        public string CustomerEmail { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public List<OrderItemDto> Items { get; set; }
            = new();
    }
}