using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Library.Persistence
{
    public class LibraryContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genres> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //name of database
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\bitta\repos\via-ste-dnp1\Lecture9\Library\Library.db");
        }
    } 
}