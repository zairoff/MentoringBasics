using System;
using System.Collections.Generic;

namespace OOP.Contract
{
    public interface IPatentDocument : IDocument
    {
        public Guid Id { get; set; }

        public List<string> Authors { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
