using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly CatalogService _service;

    public CatalogController(CatalogService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public IActionResult Add([FromBody] CatalogItem item)
    {
        return Ok(_service.Add(item));
    }
}