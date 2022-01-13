using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SlutuppgiftDatabasLotta.Data;
using SlutuppgiftDatabasLotta.Models;

namespace SlutuppgiftDatabasLotta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Book_AuthorController : ControllerBase
    {
        private readonly Context _context;

        public Book_AuthorController(Context context)
        {
            _context = context;
        }

        // GET: api/Book_Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book_Author>>> GetBöcker_Författare()
        {
           
            return await _context.BooksAndAuthor.ToListAsync();
        }

        // GET: api/Book_Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book_Author>> GetBook_Author(int id)
        {
            var book_Author = await _context.BooksAndAuthor.FindAsync(id);

            if (book_Author == null)
            {
                return NotFound((new { error = "Author not found" }));
            }

            return book_Author;
        }

        // PUT: api/Book_Author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook_Author(int id, Book_Author book_Author)
        {
            if (id != book_Author.BookId)
            {
                return BadRequest();
            }

            _context.Entry(book_Author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Book_AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Book_Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book_Author>> PostBook_Author(Book_Author book_Author)
        {
            _context.BooksAndAuthor.Add(book_Author);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Book_AuthorExists(book_Author.BookId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBook_Author", new { id = book_Author.BookId }, book_Author);
        }

        // DELETE: api/Book_Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook_Author(int id)
        {
            var book_Author = await _context.BooksAndAuthor.FindAsync(id);
            if (book_Author == null)
            {
                return NotFound();
            }

            _context.BooksAndAuthor.Remove(book_Author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Book_AuthorExists(int id)
        {
            return _context.BooksAndAuthor.Any(e => e.BookId == id);
        }
    }
}
