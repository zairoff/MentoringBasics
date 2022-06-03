using System.Threading.Tasks;

namespace ORM
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
