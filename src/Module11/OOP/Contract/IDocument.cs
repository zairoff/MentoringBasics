using System;

namespace OOP.Contract
{
    public interface IDocument
    {
        public string Title { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}
