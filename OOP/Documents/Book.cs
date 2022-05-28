using OOP.Contract;
using System;
using System.Collections.Generic;

namespace OOP.Documents
{
    public class Book : IBookDocument
    {
        public string Isbn { get; set; }
        public int Pages { get; set; }
        public List<string> Authors { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Publisher { get; set; }
    }
}
