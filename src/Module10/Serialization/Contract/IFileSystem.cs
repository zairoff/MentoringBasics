using System.IO;

namespace Serialization.Contract
{
    public interface IFileSystem
    {
        FileStream CreateFileStream(string path);

        FileStream OpenFileStream(string path);

        FileStream ReadStream(string path);

        void WriteAllText(string path, string data);

        string ReadAllText(string path);
    }
}
