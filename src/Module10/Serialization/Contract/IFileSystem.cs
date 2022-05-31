using System.IO;

namespace Serialization.Contract
{
    public interface IFileSystem
    {
        string GetFileNameWithoutExtension(string path);

        FileStream CreateFileStream(string path);

        FileStream OpenFileStream(string path);

        FileStream ReadStream(string path);

        void WriteAllText(string path, string data);

        string ReadAllText(string path);

        string[] GetFiles(string path, string filter);
    }
}
