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

        public string GetFileNameWithoutExtension(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        public string[] GetFiles(string path, string filter)
        {
            return Directory.GetFiles(path, filter);
        }

        public FileStream OpenFileStream(string path)
        {
           return new FileStream(path, FileMode.Open);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public FileStream ReadStream(string path)
        {
            return new FileStream(path, FileMode.Open, FileAccess.Read);
        }

        public void WriteAllText(string path, string data)
        {
            File.WriteAllText(path, data);
        }
    }
}
