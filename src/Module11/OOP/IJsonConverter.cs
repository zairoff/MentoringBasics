using System.Collections.Generic;

namespace OOP
{
    public interface IJsonConverter
    {
        string Serialize<T>(T entity);
        string Serialize<T>(IEnumerable<T> entity);
        T Desirialize<T>(string jsonString);
        IEnumerable<T> DesirializeList<T>(string jsonString);
    }
}
