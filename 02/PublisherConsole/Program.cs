// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using PublisherData;



//008

PubContext _context = new PubContext();

QueryFilters();
void QueryFilters()
{
    var filter = "%a%";
    var query = _context.Authors;

    var author = query
        .FirstOrDefault(a => EF.Functions.Like(a.LastName, filter));
    if(author == null)
    {
        Console.WriteLine("Not exists");
    }
    if(author != null)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}


//007

/*
 Aggregation:

    // => Aggregation
    First() // throw error if no results are returned
    FirstOrDefault() // return null if no results are returned
    Single() // throw error if no results are returned or if it exists more than one
    SingleOrDefault() // return null if no results are returned or if it exists more than one
    Last() // throw error if no results are returned
    LastOrDefault() // return null if no results are returned
    Count()
    LongCount()
    Min()
    Max()
    Average()
    Sum()
    // => No Aggregation
    ToList()
    AsEnumerable()
 
 
 */


////006

//PubContext _context = new PubContext();

//QueryFilters();
//void QueryFilters()
//{
//    var groupSize = 1;
//    var query = _context.Authors
//        .OrderByDescending(a=>a.LastName)
//        .ThenBy(a=>a.FirstName);

//    var authors = query
//        .ToList();

//    foreach (var auth in authors)
//    {
//        Console.WriteLine(auth.FirstName + " " + auth.LastName);
//    }
//}


////005

//PubContext _context = new PubContext();

//QueryFilters();
//void QueryFilters()
//{
//    var groupSize = 1;
//    var query = _context.Authors
//        .Skip(groupSize * 2)
//        .Take(groupSize);

//    var authors = query
//        .ToList();

//    foreach (var auth in authors)
//    {
//        Console.WriteLine(auth.FirstName + " " + auth.LastName);
//    }
//}

////004

//PubContext _context = new PubContext();

//QueryFilters();
//void QueryFilters()
//{
//    var query = _context.Authors;

//    var author = query
//        .Find(1);

//    if (author != null)
//    {
//        Console.WriteLine(author.FirstName + " " + author.LastName);
//    }
//}



////003

//PubContext _context = new PubContext();

//QueryFilters();
//void QueryFilters()
//{
//    var name = "01Adrian";
//    var filter = "a";
//    var query = _context.Authors
//        .Where(s => EF.Functions.Like(s.LastName, $"%{filter}%"));

//    var authors = query
//        .ToList();

//    foreach (var auth in authors)
//    {
//        Console.WriteLine(auth.FirstName + " " + auth.LastName);
//    }

//}


////002 

//PubContext _context = new PubContext();

//QueryFilters();
//void QueryFilters()
//{
//    var name = "01Adrian";
//    var query = _context.Authors
//        .Where(s => s.FirstName == name);

//    var authors = query
//        .ToList();

//    foreach (var auth in authors)
//    {
//        Console.WriteLine(auth.FirstName + " " + auth.LastName);
//    }

//}

// 001


//using (PubContext context = new PubContext())
//{
//    context.Database.EnsureCreated();
//}

// ctrl + k + d (format)
// ctrl + k + c (comment)
// ctrl + k + u (uncomment)

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

//AddAuthorWithBook();
//GetAuthorsWithBooks();

//void AddAuthorWithBook()
//{
//    var author = new Author { FirstName = "01Adrian", LastName = "01Eguez" };
//    author.Books.Add(new Book { Title = "01Title", PublishDate = DateTime.Now });
//    author.Books.Add(new Book { Title = "02Title", PublishDate = DateTime.Now });
//    author.Books.Add(new Book { Title = "03Title", PublishDate = DateTime.Now });
//    using var context = new PubContext();
//    context.Authors.Add(author);
//    context.SaveChanges();
//}


//void GetAuthorsWithBooks()
//{
//    using var context = new PubContext();
//    var authors = context.Authors.Include(args=>args.Books).ToList();
//    foreach (var author in authors)
//    {
//        Console.WriteLine(author.FirstName + " " + author.LastName);
//        foreach(var book in author.Books)
//        {
//            Console.WriteLine(book.Title + " " + book.PublishDate);
//        }
//    }
//}