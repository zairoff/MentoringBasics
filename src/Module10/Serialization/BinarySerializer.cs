using Serialization.Contract;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    public class BinarySerializer : ISerialize
    {
        private readonly IFormatter _formatter;
        private readonly IFileSystem _fileSystem;

        public BinarySerializer(IFileSystem fileSystem)
        {
            _formatter = new BinaryFormatter();
            _fileSystem = fileSystem;
        }
        public T Desirialize<T>(string path)
        {
            using var stream = _fileSystem.OpenFileStream(path);
            T result = (T)_formatter.Deserialize(stream);

            return result;
        }

        public IEnumerable<T> DesirializeList<T>(string path)
        {
            using var stream = _fileSystem.OpenFileStream(path);
            var result = (IEnumerable<T>)_formatter.Deserialize(stream);

            return result;
        }

        public void Serialize<T>(T entity, string path)
        {
            using var stream = _fileSystem.CreateFileStream(path);
            _formatter.Serialize(stream, entity);
        }

        public void Serialize<T>(IEnumerable<T> entity, string path)
        {
            using var stream = _fileSystem.CreateFileStream(path);
            _formatter.Serialize(stream, entity);
        }
    }
}
