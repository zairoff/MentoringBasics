namespace DataStructs.DoNotChange
{
    public interface IHybridFlowProcessor<T>
    {
        void Push(T item);

        T Pop();

        void Enqueue(T item);

        T Dequeue();
    }
}
