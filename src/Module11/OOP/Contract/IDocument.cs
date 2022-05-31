using System;

namespace OOP.Contract
{
    public interface IDocument
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}
