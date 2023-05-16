using Microsoft.AspNetCore.Mvc;
using PCStore_MVC.Data;
using System.Net.Mime;

namespace PCStore_MVC.Controllers
{
    [ApiController]
    [Route("api/product/image")]
    public class ProductImageController : ControllerBase
	{
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductImageController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("{id}")] // localhost.../api/product/image/1
        public async Task<ActionResult> GetImage(int id)
        {
            var image = _context.Images.FirstOrDefault(x => x.Id == id);
            if(image is null)
            {
                return NotFound();
            }

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "Products", image.Name);
            var fs = new FileStream(path, FileMode.Open);
            return File(fs, MediaTypeNames.Image.Jpeg);
        }
    }
}
