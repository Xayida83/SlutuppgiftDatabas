using SlutuppgiftDatabasLotta.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlutuppgiftDatabasLotta.Data
{
    public static class SeedDatabase
    {
        public static void Seed(Context context)
        {
            var författare = new List<Author>
            {
            new Author{ FirstName = "Astrid", LastName = "Lindgren"},
            new Author{ FirstName = "Lotta", LastName = "Berg"},
            new Author { FirstName ="Robert", LastName = "Jordan"}
            };
            context.Author.AddRange(författare);

            var customers = new List<Customer>
            {
                new Customer{FirstName="Rand", LastName="alThor"},
                new Customer{FirstName="Egwene", LastName="alVere"},
                new Customer{FirstName="Thom", LastName="Merrilin"}

            };
            context.Customer.AddRange(customers);

            var books = new List<Book>()
            {
                new Book
                {
                    BookTitle = "Pippi Långstrump på de sju haven",
                    ISBN = "123456789",
                    Rating = 3,
                    YearOfIssue = 1987,
                    Lent = false
                },
                new Book
                {
                    BookTitle = "Boken om skit",
                    ISBN = "123456790",
                    Rating = 3,
                    YearOfIssue = 1983,
                    Lent = false
                },
                new Book
                {
                    BookTitle = "Farornas väg",
                    ISBN = "12345647",
                    Rating = 4,
                    YearOfIssue = 1992,
                    Lent = false
                },
                new Book
                {
                    BookTitle = "Tidens hjul",
                    ISBN = "123456745",
                    Rating = 3,
                    YearOfIssue = 1993,
                    Lent = false
                }
            };
            context.Books.AddRange(books);
            context.SaveChanges();

            var authorBook = new List<Book_Author>
            {
                new Book_Author
                {
                   Book = books.SingleOrDefault(list => list.Id == 1),
                   Author = författare.SingleOrDefault(list => list.Id == 1)
                },
                new Book_Author 
                {
                    Book = books.SingleOrDefault(list => list.Id == 3),
                    Author= författare.SingleOrDefault(list => list.Id == 3)
                },
                  new Book_Author
                {
                    Book = books.SingleOrDefault(list => list.Id == 4),
                    Author= författare.SingleOrDefault(list => list.Id == 3 )
                }
            };
            context.BooksAndAuthor.AddRange(authorBook);
            context.SaveChanges();
        }
    }
}
