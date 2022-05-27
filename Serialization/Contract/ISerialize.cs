namespace Serialization.Contract
{
    public interface ISerialize
    {
        void Serialize<T>(T entity, string path);

        T Desirialize<T>(string path);
    }
}
