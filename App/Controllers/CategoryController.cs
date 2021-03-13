using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevMan.BookStore.App.DTO;
using Domain.Models;
using DevMan.BookStore.infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace DevMan.BookStore.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private BookStoreContext _context;

        public CategoryController(BookStoreContext context) =>
            _context = context;

        /// <summary>
        ///  Find Category by Id
        /// </summary>
        /// <param name="id">category id</param>
        /// <returns>A Category</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Category>> Get([FromRoute] int id)
        {
            var category =
                await _context.Categories.AsQueryable().FirstOrDefaultAsync(category => category.Id == id);
            if (category is null)
                return NotFound();

            return Ok((Category)category);
        }
        
        /// <summary>
        ///     Get paged categories without filter
        /// </summary>
        /// <param name="page">page index</param>
        /// <param name="size">page size</param>
        /// <returns>list of categories</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Category>>> Get([FromQuery] int page = 1, [FromQuery] int size = 30)
        {
            var categories = await _context.Categories.AsQueryable().Skip(page).Take(size).ToListAsync();
            if (categories.Any() is false)
                return NotFound();
            return Ok(categories);
        }
        
        /// <summary>
        ///   Save a category
        /// </summary>
        /// <param name="request">A category</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CategoryRequest request)
        {
            var category = Category.Create(request.Name, request.Description);
            _context.Add(category);
            await _context.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        ///     Update a category by Id
        /// </summary>
        /// <param name="id">Category id</param>
        /// <param name="request"></param>
        /// <returns>Changed category</returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] CategoryRequest request)
        {
            var category =
                await _context.Categories.AsQueryable().FirstOrDefaultAsync(category => category.Id == id);
            category.Update(request.Name, request.Description);
            await _context.SaveChangesAsync();
            return Ok(category);
        }

        /// <summary>
        ///     Delete a Category by Id
        /// </summary>
        /// <param name="id">Category Id</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            _context.Categories.Remove(Category.Create(id));
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
//https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio
//https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/web-api-help-pages-using-swagger/samples/