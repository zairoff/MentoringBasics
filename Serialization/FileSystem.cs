using Serialization.Contract;
using System.IO;

namespace Serialization
{
    public class FileSystem : IFileSystem
    {
        public FileStream CreateFileStream(string path)
        {
            return new FileStream(path, FileMode.Create);
        }

        public FileStream OpenFileStream(string path)
        {
           return new FileStream(path, FileMode.Open);
        }
    }
}
