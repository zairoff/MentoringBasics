using OOP.Contract;
using System;
using System.Collections.Generic;

namespace OOP.Documents
{
    public class LocalizedBook : IDocument
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public int Pages { get; set; }
        public List<string> Authors { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string OriginalPublisher { get; set; }
        public string LocalPublisher { get; set; }
        public string Country { get; set; }
    }
}
