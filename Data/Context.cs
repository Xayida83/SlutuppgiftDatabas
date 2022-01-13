using Microsoft.EntityFrameworkCore;
using SlutuppgiftDatabasLotta.Models;

namespace SlutuppgiftDatabasLotta.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<SlutuppgiftDatabasLotta.Models.Author> Author { get; set; }
        public DbSet<SlutuppgiftDatabasLotta.Models.Book_Author> BooksAndAuthor { get; set; }
        public DbSet<SlutuppgiftDatabasLotta.Models.Customer> Customer { get; set; }
        public DbSet<SlutuppgiftDatabasLotta.Models.Customer_Book> CustomerAndBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Nycklar i tabell Book_Author som kopplar flera böcker till flera författare och vv.
            modelBuilder.Entity<Book_Author>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<Book_Author>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.Book_Author)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.Book_Author)
                .HasForeignKey(ba => ba.AuthorId);

            //Sätter primaryKey på Cardnumber 
            modelBuilder.Entity<Customer>()
                .HasKey(c => new { c.CardNumber });

            //Nycklar i tabell Custumer_Book som kopplar flera böcker på ett Cardnumber
            modelBuilder.Entity<Customer_Book>()
                .HasKey(cb => new { cb.CardNumber, cb.BookId });

            modelBuilder.Entity<Customer_Book>()
                .HasOne(cb => cb.Customer)
                .WithMany(c => c.Customer_Book)
                .HasForeignKey(cb => cb.CardNumber);

            modelBuilder.Entity<Book>()
                .Property("YearOfIssue")
                .HasDefaultValue(null);

            modelBuilder.Entity<Book>()
                .Property("Rating")
                .HasDefaultValue(null);

        }

    }
}
