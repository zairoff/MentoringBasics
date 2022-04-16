using DataStructs.DoNotChange;
using System;

namespace DataStructs
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly DoublyLinkedList<T> _list;

        public HybridFlowProcessor()
        {
            _list = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            try
            {
                var index = _list.Length == 0 ? 0 : _list.Length - 1;
                return _list.RemoveAt(index);
            }
            catch
            {
                throw new InvalidOperationException();
            }
        }

        public void Enqueue(T item)
        {
            var index = _list.Length == 0 ? 0 : _list.Length - 1;
            _list.AddAt(index, item);
        }

        public T Pop()
        {
            try
            {
                return _list.RemoveAt(0);
            }
            catch
            {
                throw new InvalidOperationException();
            }
        }

        public void Push(T item)
        {
            _list.AddAt(0, item);
        }
    }
}
