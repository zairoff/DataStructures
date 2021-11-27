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

        public DoublyLinkedList()
        {
            _head = _tail = new Node<T>(default);
        }

        public int Length => _length;

        private bool IsEmpty()
        {
            return _head == null;
        }

        public void Add(T e)
        {
            var node = new Node<T>(e);

            if (IsEmpty())
                _head = _tail = node;
            else
            {
                _tail._next = node;
                node._prev = _tail;
                _tail = node;
            }

            _length++;
        }

        public void AddAt(int index, T e)
        {
            throw new NotImplementedException();
        }

        public T ElementAt(int index)
        {
            throw new NotImplementedException();
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
