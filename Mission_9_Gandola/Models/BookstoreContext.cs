using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mission_9_Gandola.Models
{
    public class BookstoreContext : DbContext
    {
        // methods to create context variables
        public BookstoreContext()
        {
        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
    }
}
