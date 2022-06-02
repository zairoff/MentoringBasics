using OOP.Contract;
using System;
using System.Collections.Generic;

namespace OOP.Documents
{
    public class Patent : IDocument
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<string> Authors { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
