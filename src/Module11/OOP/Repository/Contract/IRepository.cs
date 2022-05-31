using OOP.Contract;
using System;
using System.Collections.Generic;

namespace OOP.Repository.Contract
{
    public interface IRepository<T> where T : IDocument
    {
        IEnumerable<T> Find(Func<string, bool> filter);
    }
}
