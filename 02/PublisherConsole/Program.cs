// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}


//GetAuthors();
//AddAuthor();
//GetAuthors();

//void AddAuthor()
//{
//    var author = new Author { FirstName = "Vicente", LastName = "Sarzosa" };
//    using var context = new PubContext();
//    context.Authors.Add(author);
//    context.SaveChanges();
//}
//void GetAuthors()
//{
//    using var context = new PubContext();
//    var authors = context.Authors.ToList();
//    foreach (var auth in authors)
//    {
//        Console.WriteLine(auth.FirstName + " " + auth.LastName);
//    }
//}

AddAuthorWithBook();
GetAuthorsWithBooks();

void AddAuthorWithBook()
{
    var author = new Author { FirstName = "01Adrian", LastName = "01Eguez" };
    author.Books.Add(new Book { Title = "01Title", PublishDate = DateTime.Now });
    author.Books.Add(new Book { Title = "02Title", PublishDate = DateTime.Now });
    author.Books.Add(new Book { Title = "03Title", PublishDate = DateTime.Now });
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}


void GetAuthorsWithBooks()
{
    using var context = new PubContext();
    var authors = context.Authors.Include(args=>args.Books).ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        foreach(var book in author.Books)
        {
            Console.WriteLine(book.Title + " " + book.PublishDate);
        }
    }
}