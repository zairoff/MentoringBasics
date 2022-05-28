using OOP.Documents;
using OOP.Repository;
using Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOPConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book
                {
                    Isbn = "123",
                    Authors = new List<string>{"AA", "BB"},
                    Pages = 12,
                    Title = "CSharp"
                },
                new Book
                {
                    Isbn = "567",
                    Authors = new List<string>{"CC", "DD"},
                    Pages = 27,
                    Title = "Java"
                },
                new Book
                {
                    Isbn = "65789",
                    Authors = new List<string>{"EE", "FF"},
                    Pages = 721,
                    Title = "C++"
                }
            };

            var fileSystem = new FileSystem();
            var jsonSerializer = new JSONSerializer(fileSystem);
            jsonSerializer.Serialize(books, "book.json");

            var repo = new FileRepository<Book>(fileSystem, "book.json");

            var result = await repo.FindAsync(b => b.Pages == 721);
            Console.ReadLine();
        }
    }
}
