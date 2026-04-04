public class BillItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }

    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public int BillId { get; set; }
}