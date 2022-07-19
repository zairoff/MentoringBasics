using Serialization.Contract;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Serialization
{
    public class XMLSerializer : ISerialize
    {
        private readonly IFileSystem _fileSystem;

        public XMLSerializer(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public T Desirialize<T>(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var stream = _fileSystem.OpenFileStream(path);
            T result = (T)xmlSerializer.Deserialize(stream);

            return result;
        }

        public IEnumerable<T> DesirializeList<T>(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var stream = _fileSystem.OpenFileStream(path);
            var result = (IEnumerable<T>)xmlSerializer.Deserialize(stream);

            return result;
        }

        public void Serialize<T>(T entity, string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var stream = _fileSystem.CreateFileStream(path);
            xmlSerializer.Serialize(stream, entity);
        }

        public void Serialize<T>(IEnumerable<T> entity, string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var stream = _fileSystem.CreateFileStream(path);
            xmlSerializer.Serialize(stream, entity);
        }
    }
}
