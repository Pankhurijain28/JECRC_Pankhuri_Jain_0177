using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BillController : ControllerBase
{
    private readonly BillService _service;

    public BillController(BillService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Bill bill)
    {
        var result = await _service.CreateBill(bill);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }
}