using System;

namespace SlutuppgiftDatabasLotta.Models
{
    public class Customer_Book
    {
        public int CardNumber { get; set; }
        public int BookId { get; set; }
        public DateTime? LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Customer Customer { get; set; }
        public Book Book { get; set; }

       
       
    }
}
