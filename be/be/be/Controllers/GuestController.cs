//using be.Models;
using be.Models;
using be.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        public CategoryService _categoryService = new CategoryService();

        [HttpGet()]
        public ActionResult GetAllCategories()
        {
            var result = _categoryService.GetAllCategories();

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetAllCategories(int id)
        {
            var result = _categoryService.GetCategory(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
