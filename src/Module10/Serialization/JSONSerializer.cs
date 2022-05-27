using Serialization.Contract;
using System.Text.Json;

namespace Serialization
{
    public class JSONSerializer : ISerialize
    {
        private readonly IFileSystem _fileSystem;

        public JSONSerializer(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public T Desirialize<T>(string path)
        {
            var jsonString = _fileSystem.ReadAllText(path);

            var result = JsonSerializer.Deserialize<T>(jsonString);

            return result;
        }

        public void Serialize<T>(T entity, string path)
        {
            var jsonString = JsonSerializer.Serialize(entity);
            _fileSystem.WriteAllText(path, jsonString);
        }
    }
}
