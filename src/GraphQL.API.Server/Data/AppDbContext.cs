using GraphQL.API.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.API.Server.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Book>()
                .HasOne(b => b.Author);

            base.OnModelCreating(modelBuilder);
        }
    }
}
