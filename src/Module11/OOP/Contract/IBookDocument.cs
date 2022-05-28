using System.Collections.Generic;

namespace OOP.Contract
{
    public interface IBookDocument : IDocument
    {
        public string Isbn { get; set; }

        public int Pages { get; set; }

        public List<string> Authors { get; set; }
    }
}
