using OOP.Contract;
using OOP.Repository.Contract;
using Serialization.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OOP.Repository
{
    public class FileRepository<T> : IRepository<T> where T : IDocument
    {
        private readonly IFileSystem _fileSystem;
        private readonly string _path;

        public FileRepository(IFileSystem fileSystem, string path)
        {
            _fileSystem = fileSystem;
            _path = path;
        }

        public async Task<IEnumerable<T>> FindAsync(Func<T, bool> filter)
        {
            using var stream = _fileSystem.ReadStream(_path);

            // How about using IQueryable with Expression Func?
            var jsonArray = await JsonSerializer.DeserializeAsync<IEnumerable<T>>(stream);

            var result = jsonArray.Where(filter).ToList();

            return result;
        }
    }
}
