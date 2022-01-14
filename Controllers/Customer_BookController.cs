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
    public class Customer_BookController : ControllerBase
    {
        private readonly Context _context;

        public Customer_BookController(Context context)
        {
            _context = context;
        }

        // GET: api/Customer_Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer_Book>>> GetCustomer_Book()
        {
            return await _context.CustomerAndBooks.ToListAsync();
        }

        // GET: api/Customer_Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer_Book>> GetCustomer_Book(int id)
        {
            var customer_Book = await _context.CustomerAndBooks.FindAsync(id);

            if (customer_Book == null)
            {
                return NotFound();
            }

            return customer_Book;
        }

        // PUT: api/Customer_Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer_Book(int id, Customer_Book customer_Book)
        {
            if (id != customer_Book.CardNumber)
            {
                return BadRequest();
            }

            _context.Entry(customer_Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Customer_BookExists(id))
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

        // POST: api/Customer_Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer_Book>> LoanBook(Customer_Book customer_Book)
        {
            _context.CustomerAndBooks.Add(customer_Book);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Customer_BookExists(customer_Book.CardNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomer_Book", new { id = customer_Book.CardNumber }, customer_Book);
        }

        // DELETE: api/Customer_Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer_Book(int id)
        {
            var customer_Book = await _context.CustomerAndBooks.FindAsync(id);
            if (customer_Book == null)
            {
                return NotFound();
            }

            _context.CustomerAndBooks.Remove(customer_Book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Customer_BookExists(int id)
        {
            return _context.CustomerAndBooks.Any(e => e.CardNumber == id);
        }

        // api/Customer_Book/allmybooks/1
        [HttpGet]
        [Route("allmybooks/{cardNumber}")]
        public IActionResult AllMyBooks(int cardNumber)
        {
            var myBooks = _context.CustomerAndBooks.Where(x => x.CardNumber == cardNumber).ToList();
            List<MyBooks> myBookList = new();
           
            foreach (var book in myBooks)
            {
                var bookTitle = _context.Books.SingleOrDefault(x => x.Id == book.BookId).BookTitle;
                myBookList.Add(new MyBooks { BookTitle = bookTitle});
            }
            return Ok(myBookList);
        }

        internal class MyBooks
        {
            public string BookTitle { get; set; }
        }
    }

}
