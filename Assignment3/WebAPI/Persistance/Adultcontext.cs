using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace FileData
{
    public class Adultcontext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //name of database
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\bitta\repos\via-ste-dnp1\Assignment3\WebAPI\Adults.db");
        }
    }
}