using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SlutuppgiftDatabasLotta.Models
{
    public class Author
    {
        public int Id { get; set; }
      
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public ICollection<Book_Author> Book_Author { get; set; }
    }
}
