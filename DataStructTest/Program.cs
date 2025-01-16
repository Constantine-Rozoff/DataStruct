using DataStructLib;
using DataStructInterfaces;

namespace DataStructTest;

class Program
{
    class Actor {
        public string Name { get; set; }
        public DateTime Birthdate {get; set; }
    }
    
    abstract class ArtObject {
        public string Author { get; set;}
        public string Name { get; set;}
        public int Year { get; set;}
    }

    class Film : ArtObject {
        public int Length { get; set;}
        public IEnumerable<Actor> Actors { get; set;}
    }

    class Book : ArtObject {
        public int Pages { get; set; }
    }
    
    //Draft area. It's able to show a particular output of the methods
    static void Main(string[] args)
    {
        MyList<int> numbers = new MyList<int> {10, 20, 30, 40, 50};

        string str = "aaa;abb;ccc;dap";
        
        string str2 =  "aaa;xabbx;abb;ccc;dap";
        
        string str3 =  "aaa;xabbx;abb;ccc;dap;zh";
        
        string str4 =  "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh";
        
        //#1
        Console.WriteLine(string.Join(", ", numbers.Select(n => n.ToString())));
        
        //#2
        Console.WriteLine(string.Join(", ", numbers.Where(n => n % 3 == 0).Select(n => n.ToString())));
        
        //#3
        Console.WriteLine(string.Join(", ", Enumerable.Repeat("Linq", 10)));
        
        //#4
        Console.WriteLine(string.Join(", ", str.Split(";").Where(s => s.Contains("a")).Select(s => s.ToString())));
        
        //#5
        Console.WriteLine(string.Join(", ", str.Split(';').Select(s => s.Count(c => c == 'a'))));
        
        //#6
        Console.WriteLine(string.Join(", ", str2.Split(';').Select(s => s.Contains("abb"))));
        
        //#7
        Console.WriteLine(string.Join(", ", str2.Split(';').Where(s => s.Length > 3).Select(s => s.ToString())));
        
        //#8
        Console.WriteLine(string.Join(", ", str2.Split(';').Average(s => s.Length)));
        
        //#9
        Console.WriteLine(string.Join(", ", str3.Split(';').Where(s => s.Length <= 2).Reverse().Select(s => s.ToString())));
        
        //#10
        Console.WriteLine(string.Join(", ", str4.Split(';').Where(s => s.StartsWith("aa")).Where(s => s.Contains("bb")).Select(s => s.ToString())));

        Console.WriteLine("-----------------------------");
        
        //linq#2
        
        var data = new List<object>()
        {
            "Hello",
            new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
            new List<int>() { 4, 6, 8, 2 },
            new string[] { "Hello inside array" },
            new Film()
            {
                Author = "Martin Scorsese", Name = "The Departed", Actors = new List<Actor>()
                {
                    new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22) },
                    new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11) },
                    new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10) }
                }
            },
            new Film()
            {
                Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>()
                {
                    new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10) },
                    new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11) },
                }
            },
            new Book() { Author = "Stephen King", Name = "Finders Keepers", Pages = 200 },
            "Leonardo DiCaprio"
        };

        //#1
        var allElements = data.Select(item => item switch
        {
            string str => str,
            Book book => $"Book: {book.Name} by {book.Author}, {book.Pages} pages",
            Film film => $"Film: {film.Name} by {film.Author}, " +
                         $"Actors: {string.Join(", ", film.Actors.Select(a => $"{a.Name} - {a.Birthdate:yyyy-MM-dd}"))}",
            IEnumerable<int> numbers => $"List of numbers: {string.Join(", ", numbers)}",
            IEnumerable<string> strings => $"Array of strings: {string.Join(", ", strings)}",
            _ => item?.ToString() ?? "Unknown"
        });
        
        foreach (var element in allElements)
        {
            Console.WriteLine(element);
        }
        
        Console.WriteLine("-----------------------------");
        
        //#2
        var allDetails = data.SelectMany(item =>
        {
            if (item is Film film)
            {
                return new[]
                {
                    $"Film: {film.Name} by {film.Author}"
                }.Concat(film.Actors.Select(actor => $"Actor: {actor.Name} - {actor.Birthdate:yyyy-MM-dd}"));
            }

            return Enumerable.Empty<string>();
        });
        
        foreach (var element in allDetails)
        {
            Console.WriteLine(element);
        }

        Console.WriteLine(string.Join(", ", data.Last().ToString()));
        
        Console.WriteLine("-----------------------------");
        
        //#3
        var actorsBornInAugust = data
            .OfType<Film>()
            .SelectMany(film => film.Actors) 
            .Where(actor => actor.Birthdate.Month == 8)
            .Distinct()
            .Select(actor => $"{actor.Name} - {actor.Birthdate:yyyy-MM-dd}");

        foreach (var actor in actorsBornInAugust)
        {
            Console.WriteLine(actor);
        }
        
        Console.WriteLine("-----------------------------");
        
        //#4
        var theOldestActors = data
            .OfType<Film>()
            .SelectMany(film => film.Actors) 
            .Where(actor => actor.Birthdate.Year <= 1951)
            .Select(actor => $"{actor.Name} - {actor.Birthdate:yyyy-MM-dd}");

        foreach (var actor in theOldestActors)
        {
            Console.WriteLine(actor);
        }
        
        Console.WriteLine("-----------------------------");
        
        //#5
        var booksByAuthor = data
            .OfType<Book>()
            .GroupBy(book => book.Author) 
            .Select(group => new { Author = group.Key, Count = group.Count() });
        
        int count = 0;
        
        foreach (var entry in booksByAuthor)
        {
            Console.WriteLine($"{entry.Author}: {entry.Count}");
            count++;
        }

        Console.WriteLine("Total books: " + count);
        
        Console.WriteLine("---------------6-------------");
        
        //#6
        booksByAuthor = data
            .OfType<Book>()
            .GroupBy(book => book.Author) 
            .Select(group => new { Author = group.Key, Count = group.Count() });
        
        foreach (var entry in booksByAuthor)
        {
            Console.WriteLine($"{entry.Author}: {entry.Count}");
        }

        var filmsByAuthor = data
            .OfType<Film>()
            .GroupBy(book => book.Author) 
            .Select(group => new { Author = group.Key, Count = group.Count() });

        foreach (var entry in filmsByAuthor)
        {
            Console.WriteLine($"{entry.Author}: {entry.Count}");
        }
    }
}