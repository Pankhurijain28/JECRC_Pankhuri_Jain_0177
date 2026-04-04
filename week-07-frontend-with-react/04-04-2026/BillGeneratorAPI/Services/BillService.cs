using Microsoft.EntityFrameworkCore;

public class BillService
{
    private readonly AppDbContext _context;

    public BillService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Bill> CreateBill(Bill bill)
    {
        bill.InvoiceNumber = $"INV-{DateTime.Now.Ticks}";

        bill.SubTotal = bill.Items.Sum(i => i.Price * i.Quantity);
        bill.Tax = bill.SubTotal * 0.18m;
        bill.Total = bill.SubTotal + bill.Tax - bill.Discount;

        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();

        return bill;
    }

    public List<Bill> GetAll()
    {
        return _context.Bills.Include(b => b.Items).ToList();
    }
}