using System;
using System.Collections.Generic;

namespace Katas.RecentlyUsedList
{
    public class List
    {
        private readonly LinkedList<string> _items;
        private readonly HashSet<string> _holder;
        private readonly int _capacity;
        private int _count = 0;

        public List(int capacity = 5)
        {
            _items = new LinkedList<string>();
            _holder = new HashSet<string>();
            _capacity = capacity;
        }

        public void Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException();

            if (_count == _capacity)
                throw new OverflowException();

            if (_holder.Contains(input))
                throw new InvalidOperationException($"List already has {input} input");

            _holder.Add(input);
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
    }
}
