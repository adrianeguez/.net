using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PublisherDomain;

namespace PublisherData
{
    public class PubContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Cover> Cover{ get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<AuthorByArtist> AuthorsByArtist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase4"
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
            modelBuilder.Entity<AuthorByArtist>()
                .HasNoKey() // No tiene PK
                .ToView(nameof(AuthorsByArtist)); // Mapeado a vista
        }
    }
}