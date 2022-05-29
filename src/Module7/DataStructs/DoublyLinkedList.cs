using System;
using System.Collections;
using DataStructs.DoNotChange;
using System.Collections.Generic;

namespace DataStructs
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private class Node<T>
        {
            public T _data;
            public Node<T> _prev;
            public Node<T> _next;

            public Node(T data)
            {
                _data = data;
            }
        }

        private Node<T> _head;
        private Node<T> _tail;
        private Node<T> _runner;
        private Node<T> _mover;
        private int _length;

        public int Length => _length;

        private bool IsEmpty()
        {
            return _head == null;
        }

        public void Add(T e)
        {
            var node = new Node<T>(e);

            if (IsEmpty())
                Initialize(node);
            else
            {
                _tail._next = node;
                node._prev = _tail;
                _tail = node;
            }

            _length++;
        }

        private void Initialize(Node<T> node)
        {
            _mover = _runner = _head = _tail = node;
        }

        public void AddAt(int index, T e)
        {
            if (index > _length || index < 0)
                throw new IndexOutOfRangeException();

            var node = new Node<T>(e);
            _length++;

            if (IsEmpty())
            {
                Initialize(node);
                return;
            }

            if (index == 0)
            {
                AddFirst(node);
                return;
            }

            if (index == (_length - 1))
            {
                AddLast(node);
                return;
            }

            var runner = _head;

            while (index-- > 0)
                runner = runner._next;

            var prev = runner._prev;
            prev._next = node;
            node._next = runner;
            node._prev = prev;
        }

        private void AddFirst(Node<T> node)
        {
            node._next = _head;
            _head._prev = node;
            _mover = _runner = _head = node;
        }

        private void AddLast(Node<T> node)
        {
            _tail._next = node;
            node._prev = _tail;
            _tail = node;
        }

        public T ElementAt(int index)
        {
            if (index >= _length || index < 0)
                throw new IndexOutOfRangeException();

            var runner = _head;
            while (index-- > 0)
                runner = runner._next;

            return runner._data;
        }

        public void Remove(T item)
        {
            var runner = _head;
            while (runner != null)
            {
                if (item.Equals(runner._data))
                    break;

                runner = runner._next;
            }

            if (runner == null)
                return;

            _length--;

            if (runner._prev == null)
            {
                RemoveFirst();
                return;
            }

            if (runner._next == null)
            {
                RemoveLast();
                return;
            }

            runner._prev._next = runner._next;
            runner._next._prev = runner._prev;
        }

        private T RemoveFirst()
        {
            var value = _head._data;
            _mover = _runner = _head = _head._next;
            _mover._prev = _runner._prev = _head._prev = null;
            return value;
        }

        private T RemoveLast()
        {
            var value = _tail._data;
            _tail = _tail._prev;
            _tail._next = null;
            return value;
        }

        public T RemoveAt(int index)
        {
            if (index >= _length || index < 0)
                throw new IndexOutOfRangeException();

            _length--;

            if (index == 0)
                return RemoveFirst();

            if (index == _length)
                return RemoveLast();

            var runner = _head;
            while (index-- > 0)
                runner = runner._next;

            runner._prev._next = runner._next;
            runner._next._prev = runner._prev;
            return runner._data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var head = _head;
            while (head != null)
            {
                yield return head._data;
                head = head._next;
            }
        }
    }
}
