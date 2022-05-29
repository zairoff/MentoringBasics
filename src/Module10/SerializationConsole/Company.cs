using System;
using System.Runtime.Serialization;

namespace SerializationConsole
{
    [Serializable]
    public class Company : ISerializable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Id), Id);
            info.AddValue(nameof(Name), Name);
            info.AddValue(nameof(Address), Address);
        }

        protected Company(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            Id = serializationInfo.GetInt32(nameof(Id));
            Name = serializationInfo.GetString(nameof(Name));
            Address = serializationInfo.GetString(nameof(Address));
        }

        public Company()
        {
        }
    }
}
