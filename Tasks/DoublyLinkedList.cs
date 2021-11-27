using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>, IEnumerator<T>
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

        public T Current => _mover._data;

        object IEnumerator.Current => _mover._data;

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
            _mover = _runner = _head = _tail = node;
        }

        public void AddAt(int index, T e)
        {
            if (index > _length || index < 0)
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

            if(index == _length)
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
            while(runner != null)
            {
                if (item.Equals(runner._data))
                    break;

                runner = runner._next;
            }

            if (runner == null)
                return;

            if (runner._prev == null)
            {
                RemoveFirst();
                _length--;
                return;
            }

            if (runner._next == null)
            {
                RemoveLast();
                _length--;
                return;
            }

            runner._prev._next = runner._next;
            runner._next._prev = runner._prev;
            _length--;
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

            if(index == 0)
            {
                _length--;
                return RemoveFirst();                
            }

            if(index == (_length - 1))
            {
                _length--;
                return RemoveLast();
            }

            var runner = _head;
            while (index-- > 0)
                runner = runner._next;

            runner._prev._next = runner._next;
            runner._next._prev = runner._prev;
            _length--;
            return runner._data;
        }

        public bool MoveNext()
        {
            _mover = _runner;
            if (_mover == null) return false;
            _runner = _runner._next;
            return (_mover != null);
        }

        public void Reset()
        {
            _mover = _runner = _head;
        }

        public void Dispose()
        {
            _mover = _runner = _head;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
    }
}
