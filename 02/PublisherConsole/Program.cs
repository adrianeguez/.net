// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using PublisherData;



//011 - Consultas con relaciones `Include`

PubContext _context = new PubContext();

queryfilters();
void queryfilters()
{
    var filter = "%a%";
    var query = _context.Authors;

    var authors = query
        .Select(a=> new {
            nombre = a.FirstName + " " + a.LastName,
            Books = a.Books
        })
        // .Where(a => EF.Functions.Like(a.nombre, filter))
        // .Include(a => a.Books.Where(book => book.Title == "Titulo"))
        // .Include(a => a.Novelas)
        // .Include(a => a.Books.OtraRelacion)
        // .ThenInclude(books=>books.OtraRelacion)
        .ToList();
    foreach (var auth in authors)
    {
        Console.WriteLine(auth.nombre);
    }
}


//010 -> Logs

/*
    Para usar los logs, se pone en el UseSqlServerla funcion `Log.To`:

    `PubContext.cs`

    ```
    optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase3"
                ).LogTo(
                Console.WriteLine, // funcion que muestraq
                new[] { // Arreglo de categorias
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information // Nivel de logs
                );
                // .EnableSensitiveDataLogging(); // Se puede habilitar mostrar los datos en las consultas
    ```
 
 
 
 */

//009 -> Migrations


/*
    Para revisar todo podemos usar SQL Serveer Management Studio:
    1. Instalar
    2. En la consola:
    > SQLLocalDB info # En la consola
    MSSQLLocalDB
    > SQLLocalDB info MSSQLLocalDB # En la consola 
    Name:               MSSQLLocalDB
    Version:            15.0.4153.1
    Shared name:
    Owner:              ADRIAN-WINDOWS\EADEP
    Auto-create:        Yes
    State:              Running
    Last start time:    31/8/2023 8:19:08
    Instance pipe name: np:\\.\pipe\LOCALDB#3C74E3B1\tsql\query
    Llenar el "server name" con: np:\\.\pipe\LOCALDB#3C74E3B1\tsql\query
 
    1. Instalar Entity Framework Tools de microsoft en el proyecto principal
    2. Abrir el Package Manager Console
    3. Seleccionar el proyecto de datos (Publisher Data)
    
    Comandos:
    PM> get-help entityframework
    PM> get-help add-migration
    PM> add-migration [name = initial]

    En este caso se crea una carpeta llamada Migrations y se tiene initial y Snapshot
    # dotnet ef database update (ejecuta la migracion)
    # dotnet ef migrations script (crea sql)

    Comandos:
    PM> update-database -verbose


    SCRIPT MIGRATION:
    PM> script-migration 
    PM> script-migration -From <PreviousMigration> -To <LastMigration>
    PM> script-migration-idempotent
    PM> script-migration-idempotent -From <PreviousMigration> -To <LastMigration>

    // Mapear una base de datos:
    PM> Scaffold-DbContext 'Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase3;'
 */



////008

//PubContext _context = new PubContext();

//queryfilters();
//void queryfilters()
//{
//    var filter = "%a%";
//    var query = _context.Authors;

//    var author = query
//        .FirstOrDefault(a => EF.Functions.Like(a.LastName, filter));
//    if (author == null)
//    {
//        Console.WriteLine("not exists");
//    }
//    if (author != null)
//    {
//        Console.WriteLine(author.FirstName + " " + author.LastName);
//    }
//}


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