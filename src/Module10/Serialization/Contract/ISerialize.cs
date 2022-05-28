using System.Collections.Generic;

namespace Serialization.Contract
{
    public interface ISerialize
    {
        void Serialize<T>(T entity, string path);
        void Serialize<T>(IEnumerable<T> entity, string path);
        T Desirialize<T>(string path);
        IEnumerable<T> DesirializeList<T>(string path);
    }
}
