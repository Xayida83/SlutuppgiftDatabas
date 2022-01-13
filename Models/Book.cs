using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SlutuppgiftDatabasLotta.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string ISBN { get; set; }
        public int? YearOfIssue { get; set; }
        public int? Rating { get; set; }
        public bool Lent { get; set; } = false; 
        

        public ICollection<Book_Author> Book_Author { get; set; }
        public ICollection<Customer_Book> Customer_Book { get; set; }
       
        public Book()
        {

        }
    }
}
