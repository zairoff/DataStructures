using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
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
        private int _length;

        public int Length => _length;

        private bool IsEmpty()
        {
            return _head == null;
        }

        public void Print()
        {
            var runner = _head;

            while(runner != null)
            {
                Console.WriteLine(runner._data);
                runner = runner._next;
            }
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
            _head = _tail = node;
        }

        public void AddAt(int index, T e)
        {
            if (index >= _length || index < 0)
                throw new IndexOutOfRangeException();

            var node = new Node<T>(e);

            if (IsEmpty())
            {
                Initialize(node);
                _length++;
                return;
            }

            if (index == 0)
            {
                AddFirst(node);
                _length++;
                return;
            }

            if(index == (_length - 1))
            {
                AddLast(node);
                _length++;
                return;
            }

            var runner = _head;

            while(index-- > 0)
                runner = runner._next;

            var prev = runner._prev;
            prev._next = node;
            node._next = runner;
            node._prev = prev;
            _length++;
        }

        private void AddFirst(Node<T> node)
        {
            node._next = _head;
            _head._prev = node;
            _head = node;
        }

        private void AddLast(Node<T> node)
        {
            _tail._prev._next = node;
            node._prev = _tail._prev;
            _tail._prev = node;
            node._next = _tail;
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

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public T RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
