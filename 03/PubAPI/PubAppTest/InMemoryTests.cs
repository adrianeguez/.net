using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;
using System.Diagnostics;

namespace PubAppTest
{
    [TestClass]
    public class InMemoryTest
    {
        [TestMethod]
        public void CanInsertAuthorIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder<PubContext>();
            builder.UseInMemoryDatabase("CanInsertAuthorIntoDatabase");
            using (var context = new PubContext(builder.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var author = new Author { FirstName = "a", LastName = "b" };
                context.Authors.Add(author);
                Debug.WriteLine($"Before Save: {author.AuthorId}");
                context.SaveChanges();
                Debug.WriteLine($"After Save: {author.AuthorId}");
                Assert.AreNotEqual( 0, author.AuthorId );
            }
        }
        [TestMethod]
        public void CanInsertAuthorIntoDatabaseState()
        {
            var builder = new DbContextOptionsBuilder<PubContext>();
            builder.UseInMemoryDatabase("CanInsertAuthorIntoDatabase");
            using (var context = new PubContext(builder.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var author = new Author { FirstName = "a", LastName = "b" };
                context.Authors.Add(author);
                Assert.AreEqual(EntityState.Added, context.Entry(author).State);
            }
        }
    }
}