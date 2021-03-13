using System.Threading.Tasks;
using DevMan.BookStore.App.DTO;
using DevMan.BookStore.Domain.Models;
using DevMan.BookStore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DevMan.BookStore.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AuthorController(BookStoreContext context) =>
            _context = context;


        /// <summary>
        ///   Get an Author by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A filtered Author</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            var author = await _context.Authors.AsQueryable().FirstOrDefaultAsync(author => author.Id == id);

            if (author is null)
                return NotFound();
            return Ok(author);
        }

        /// <summary>
        /// Save an Author
        /// </summary>
        /// <param name="request">An Author</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorRequest request)
        {

            _context.Add(Author.Create(request.Name, request.Birthday));
            await _context.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Get an Author
        /// </summary>
        /// <param name="id">Author id</param>
        /// <param name="request">Author</param>
        /// <returns>An Author</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] AuthorRequest request)
        {
            var author = await _context.Authors.AsQueryable().FirstAsync(author => author.Id == id);
            author.Update(request.Name, request.Birthday);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Delete an Author
        /// </summary>
        /// <param name="id">Author id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            _context.Authors.Remove(Author.Create(id));
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}