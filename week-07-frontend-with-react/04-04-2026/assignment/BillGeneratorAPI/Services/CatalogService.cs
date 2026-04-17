public class CatalogService
{
    private readonly AppDbContext _context;

    public CatalogService(AppDbContext context)
    {
        _context = context;
    }

    public List<CatalogItem> GetAll() => _context.CatalogItems.ToList();

    public CatalogItem Add(CatalogItem item)
    {
        _context.CatalogItems.Add(item);
        _context.SaveChanges();
        return item;
    }
}