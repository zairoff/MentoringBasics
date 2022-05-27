using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "company.data";

            IFormatter formatter = new BinaryFormatter();

            SerializeItem(fileName, formatter); 
            DeserializeItem(fileName, formatter); 
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static void SerializeItem(string fileName, IFormatter formatter)
        {
            var company = new Company { Id = 1, Name = "EPAM", Address = "Minsk" };
            var stream = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(stream, company);
            stream.Close();
        }

        public static Company DeserializeItem(string fileName, IFormatter formatter)
        {
            var stream = new FileStream(fileName, FileMode.Open);
            var company = (Company)formatter.Deserialize(stream);
            return company;
        }
    }
}
