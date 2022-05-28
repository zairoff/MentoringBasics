using OOP.Contract;
using System;
using System.Collections.Generic;

namespace OOP.Documents
{
    public class Patent : IPatentDocument
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<string> Authors { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
