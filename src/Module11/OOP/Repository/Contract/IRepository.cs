using OOP.Contract;
using System.Collections.Generic;

namespace OOP.Repository.Contract
{
    public interface IRepository<T> where T : IDocument
    {
        IEnumerable<T> Find(IFilter filter);
    }
}
