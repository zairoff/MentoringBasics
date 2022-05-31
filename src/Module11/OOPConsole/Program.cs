using OOP.Contract;
using OOP.Documents;
using OOP.Repository;
using System;

namespace OOPConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
                return;

            var repo = new FileRepository<IDocument>(AppDomain.CurrentDomain.BaseDirectory);

            var documents = repo.Find(b => b.Contains(args[0]));

            foreach(var document in documents)
            {
                Print(document);
            }
        }

        static void Print(IDocument document)
        {
            var type = document.GetType().Name.ToLower();
            switch (type)
            {
                case "book":
                    var book = (Book)document;
                    Console.Write($"Book found: \r\nid:{book.Id}, title:{book.Title}\r\n");
                    break;
                case "patent":
                    var patent = (Patent)document;
                    Console.Write($"Patent found: \r\nid:{patent.Id}, title:{patent.Title}\r\n");
                    break;
                case "magazine":
                    var magazine = (Magazine)document;
                    Console.Write($"Magazine found: \r\nid:{magazine.Id}, title:{magazine.Title}\r\n");
                    break;
                default: break;
            }
        }
    }
}
