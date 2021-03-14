using System.Linq;
using System.Threading.Tasks;
using DevMan.BookStore.App.DTO;
using DevMan.BookStore.Domain.Models;
using DevMan.BookStore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevMan.BookStore.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly BookStoreContext _context;

        public BookController(BookStoreContext context) =>
            _context = context;

        /// <summary>
        ///     Save a book
        /// </summary>
        /// <param name="request">Book</param>
        /// <returns>Saved book</returns>
        [HttpPost]
        public async Task<ActionResult<Book>> Post(BookRequest request)
        {
            //get authors and categories states
            var authors = await _context.Authors.AsQueryable().Where(author => request.Authors.Contains(author.Id)).ToListAsync();
            var categories = await _context.Categories.AsQueryable().Where(category => request.Categories.Contains(category.Id)).ToListAsync();
            // Other way to do this is detach the states save book and after attach author and categories.
            // Other possibility is create manually a relational table/ link table and save manually into this table

            var book = Book.Create(
                        request.Title,
                        request.BriefDescription,
                        request.Description,
                        authors,
                        categories
                    );
            _context.Add(book);

            await _context.SaveChangesAsync(true);

            return Ok(book);
        }
        /// <summary>
        ///     Update a book by id
        /// </summary>
        /// <param name="id">book id</param>
        /// <param name="request">book</param>
        /// <returns>updated book</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] BookRequest request)
        {
            var authors = await _context.Authors.AsQueryable().Where(author => request.Authors.Contains(author.Id)).ToListAsync();
            var categories = await _context.Categories.AsQueryable().Where(categories => request.Authors.Contains(categories.Id)).ToListAsync();

            var book = await _context.Books.AsQueryable().FirstAsync(Book => Book.Id == 1);
            book.Update(request.Title, request.BriefDescription, request.Description, authors, categories);
            return Ok(book);
        }
        
        /// <summary>
        /// Delete a book by Id
        /// </summary>
        /// <param name="id">book id</param>
        /// <returns>Deleted book</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var book = Book.Create(id);
            _context.Remove(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        /// <summary>
        /// Get a book by id
        /// </summary>
        /// <param name="id">book id</param>
        /// <returns>Filtered book</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get([FromRoute] int id)
        {
            var book = await _context.Books
                                .Include(b => b.Authors)
                                .Include(b => b.Categories)
                                .FirstAsync(b => b.Id == id);
            return Ok(book);
        }
    }
}