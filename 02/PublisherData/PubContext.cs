using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PublisherDomain;

namespace PublisherData
{
    public class PubContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase3"
                ).LogTo(
                Console.WriteLine,
                new[] {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information
                )
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, FirstName = "Adrian", LastName = "Eguez" }
                );
            var authorList = new Author[]
            {
                new Author { AuthorId = 2, FirstName = "Vicente", LastName = "Eguez" },
                new Author { AuthorId = 3, FirstName = "Carolina", LastName = "Eguez" },
                new Author { AuthorId = 4, FirstName = "Adrian", LastName = "Sarzosa" }
            };
            modelBuilder.Entity<Author>().HasData(authorList);
        }
    }
}