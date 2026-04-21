using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PR4
{
    public class Author { public string Name { get; set; } = ""; public List<Book> Books { get; set; } = new(); }
    public class Book { public string Title { get; set; } = ""; public Author? Author { get; set; } }

    public class Task3
    {
        public static void Run()
        {
            Author author = new Author { Name = "Шевченко" };
            author.Books.Add(new Book { Title = "Кобзар", Author = author });

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            Console.WriteLine("Серіалізація автора з книгами:");
            Console.WriteLine(JsonSerializer.Serialize(author, options));
        }
    }
}