public class Bill
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public decimal SubTotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }

    public List<BillItem> Items { get; set; } = new();
}