using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;
using System.Diagnostics;

namespace PubAppTest
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CanInsertAithorIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder<PubContext>();
            builder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase4"
                );
            using (var context = new PubContext(builder.Options))
            {
                // context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var author = new Author { FirstName = "a", LastName = "b" };
                context.Authors.Add(author);
                // Debug.WriteLine($"Before Save: {author.AuthorId}");
                context.SaveChanges();
                // Debug.WriteLine($"After Save: {author.AuthorId}");
                Assert.AreNotEqual(0, author.AuthorId);
            }
        }
    }
}