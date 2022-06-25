using OOP.Contract;
using OOP.Documents;
using OOP.Repository.Contract;
using Serialization;
using Serialization.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP.Repository
{
    public class FileRepository<T> : IRepository<T> where T : IDocument
    {
        private readonly IFileSystem _fileSystem;
        private readonly string _path;
        private const string _fileType = "*.json";

        public FileRepository(string path)
        {
            _fileSystem = new FileSystem();
            _path = path;
        }

        public IEnumerable<T> Find(IFilter filter)
        {
            var allFiles = _fileSystem.GetFiles(_path, _fileType);

            var filteredFiles = allFiles.Where(file => file.Contains(filter.Number));

            var result = new List<T>();

            foreach(var file in filteredFiles)
            {
                var fileName = _fileSystem.GetFileNameWithoutExtension(file);
                var splited = fileName.Split('_');

                if (splited.Length < 2)
                    throw new InvalidOperationException();

                var jsonString = _fileSystem.ReadAllText(file);
                var type = GetType(splited[0]);

                var method = typeof(JsonConverter).GetMethod("Desirialize");
                var jsonRef = method.MakeGenericMethod(type);
                var obj = (T)jsonRef.Invoke(new JsonConverter(), new object[] { jsonString });
                result.Add(obj);
            }

            return result;
        }

        // It breaks Open Closed Principle, when new document will be added, this method should be modified
        private static Type GetType(string type)
        {
            Type result;
            switch (type.ToLower())
            {
                case "book": result = typeof(Book); break;
                case "patent": result = typeof(Patent); break;
                case "magazine": result = typeof(Magazine); break;
                default: result = typeof(IDocument); break;
            }

            return result;
        }
    }
}
