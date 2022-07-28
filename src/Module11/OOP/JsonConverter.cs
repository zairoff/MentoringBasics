using System.Collections.Generic;
using System.Text.Json;

namespace OOP
{
    public class JsonConverter : IJsonConverter
    {
        public T Desirialize<T>(string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        public IEnumerable<T> DesirializeList<T>(string jsonString)
        {
            return JsonSerializer.Deserialize<IEnumerable<T>>(jsonString);
        }

        public string Serialize<T>(T entity)
        {
            return JsonSerializer.Serialize(entity);
        }

        public string Serialize<T>(IEnumerable<T> entity)
        {
            return JsonSerializer.Serialize(entity);
        }
    }
}
