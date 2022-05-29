using System;
using System.Collections.Generic;

namespace Katas.Kata1
{
    public class RecentlyUsedList
    {
        private readonly LinkedList<string> _items;
        private readonly int _capacity;
        private int _count = 0;

        public RecentlyUsedList(int capacity = 5)
        {
            _items = new LinkedList<string>();
            _capacity = capacity;
        }

        public void Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException();

            if (_count == _capacity)
                throw new OverflowException();

            if (IsValueExist(input))
                throw new InvalidOperationException($"List already has {input} input");

            _items.AddFirst(input);
            _count++;
        }

        public string this[int index]
        {
            get
            {
                if (index >= _capacity || index >= _count)
                    throw new IndexOutOfRangeException();

                var move = _items.First;
                var dest = _items.First;

                while (index-- >= 0)
                {
                    dest = move;
                    move = move.Next;
                }

                return dest.Value;
            }
        }

        private bool IsValueExist(string value)
        {
            var head = _items.First;
            while (head != null)
            {
                if (head.Value.Equals(value))
                    return true;

                head = head.Next;
            }
            return false;
        }
    }
}
