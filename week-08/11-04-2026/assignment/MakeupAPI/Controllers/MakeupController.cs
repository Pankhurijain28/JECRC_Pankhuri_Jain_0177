using Microsoft.AspNetCore.Mvc;
using MakeupAPI.Models;
using MakeupAPI.Services;

namespace MakeupAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MakeupController : ControllerBase
    {
        private readonly ProductService _service;

        public MakeupController()
        {
            _service = new ProductService();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _service.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            var result = _service.Update(id, product);
            if (!result) return NotFound();
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (!result) return NotFound();
            return Ok("Deleted Successfully");
        }
    }
}