using OOP.Contract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OOP.Repository.Contract
{
    public interface IRepository<T> where T : IDocument
    {
        Task<IEnumerable<T>> FindAsync(Func<T, bool> filter);
    }
}
