﻿using Serialization.Contract;
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

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteAllText(string path, string data)
        {
            File.WriteAllText(path, data);
        }
    }
}