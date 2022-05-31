using OOP.Contract;
using System;

namespace OOP.Documents
{
    public class Magazine : IDocument
    {
        public int Id { get; set; }
        public string Publisher { get; set; }
        public int ReleaseNumber { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
