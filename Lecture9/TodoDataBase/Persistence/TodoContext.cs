using Microsoft.EntityFrameworkCore;
using TodoDataBase.Models;

namespace TodoDataBase.Persistence {
    public class TodoContext : DbContext {
        
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\bitta\repos\via-ste-dnp1\Lecture9\TodoDataBase\TodoDataBase.db");
        }
    }
}