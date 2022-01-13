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
    public class CustomersController : ControllerBase
    {
        private readonly Context _context;

        public CustomersController(Context context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _context.Customer.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CardNumber)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customer.Add(customer);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CardNumber }, customer);
        }
        //Låna en bok
        //POST: api/Customers/loanabook/1/2
        [HttpPost]
        [Route("loanabook/{cardNumber}/{bookId}")]
        public async Task<IActionResult> LoanABook(int cardNumber, int bookId)
        {
            var customer = await _context.Customer.SingleOrDefaultAsync(c => c.CardNumber == cardNumber);
            if (customer is null) return BadRequest(new { error = "Cardnumber dont exist" });

            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == bookId && b.Lent == false);
            if (book is null) return BadRequest(new { error = "Book dont exist" });

            var rentalObject = new Customer_Book
            {
                BookId = bookId,
                CardNumber = cardNumber,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(30)
            };

            _context.CustomerAndBooks.Add(rentalObject);

            book.Lent = true;

            await _context.SaveChangesAsync();

            return Ok();
        }
        //Lämna tillbaka en bok
        //POST: api/Customers/returnabook/1/2
        [HttpPost]
        [Route("returnabook/{cardNumber}/{bookId}")]
        public async Task<IActionResult> ReturnABook(int cardNumber, int bookId)
        {
            var customer = await _context.Customer.SingleOrDefaultAsync(c => c.CardNumber == cardNumber);
            if (customer is null) return BadRequest(new { error = "Cardnumber dont exist" });

            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == bookId);
            if (book is null) return BadRequest(new { error = "Book dont exist" });

            var rentalObject = await _context.CustomerAndBooks.SingleOrDefaultAsync(cb => cb.CardNumber == cardNumber && cb.BookId == bookId);
            if (rentalObject is null) return BadRequest(new { error = "Something went wrong" });

            _context.CustomerAndBooks.Remove(rentalObject);

            book.Lent = false;

            await _context.SaveChangesAsync();
            
            return Ok();
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound((new { error = "Customer not found" }));
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CardNumber == id);
        }
    }
}
