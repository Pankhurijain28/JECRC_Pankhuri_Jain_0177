namespace FoodOrdering.API.DTOs
{
    public class OrderItemDto
    {
        public int FoodItemId { get; set; }

        public string FoodName { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}