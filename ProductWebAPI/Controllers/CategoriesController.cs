using Microsoft.AspNetCore.Mvc;
using BusinessObjects;
using Services.Interfaces;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _context;

        public CategoriesController(ICategoryService context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return _context.GetCategories();
        }
    }
}
