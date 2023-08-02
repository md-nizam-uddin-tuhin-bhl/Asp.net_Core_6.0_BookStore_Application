using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.Domain;

namespace WebApplication3.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options ): base(options) 
        {

        }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<Author> author { get; set; }
        public DbSet<Book> books { get; set; }
   
    }
}
