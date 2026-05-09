using FoodOrdering.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Upload(
            [FromForm] UploadImageDto model)
        {
            if (model.File == null ||
                model.File.Length == 0)
            {
                return BadRequest(
                    "No file uploaded.");
            }

            var uploadsFolder =
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "Images");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(
                    uploadsFolder);
            }

            var uniqueFileName =
                Guid.NewGuid().ToString() +
                "_" +
                model.File.FileName;

            var filePath =
                Path.Combine(
                    uploadsFolder,
                    uniqueFileName);

            using (var stream =
                   new FileStream(
                       filePath,
                       FileMode.Create))
            {
                await model.File.CopyToAsync(stream);
            }

            var imageUrl =
                $"{Request.Scheme}://" +
                $"{Request.Host}/Images/" +
                $"{uniqueFileName}";

            return Ok(new
            {
                imageUrl
            });
        }
    }
}