using System.IO;

namespace Serialization.Contract
{
    public interface IFileSystem
    {
        FileStream CreateFileStream(string path);

        FileStream OpenFileStream(string path);
    }
}
