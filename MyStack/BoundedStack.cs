using System;

namespace MyStack
{
    public class BoundedStack : IStack
    {
        private readonly int _capacity;
        private int _size;
        private readonly int[] _elements;

        public static BoundedStack Make(int capacity)
        {
            if (capacity < 0)
                throw new IllegalCapacityException();
            return new BoundedStack(capacity);
        }

        private BoundedStack(int capacity)
        {
            _capacity = capacity;
            _elements = new int[capacity];
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public int GetSize()
        {
            return _size;
        }

        public void Push(int element)
        {
            if (_size == _capacity)
                throw new OverflowException();
            _elements[_size++] = element;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new UnderflowException();
            return _elements[--_size];
        }

        public int? FindPosition(int element)
        {
            for (var position = _elements.Length - 1; position >= 0; --position)
                if (_elements[position] == element)
                    return _elements.Length - 1 - position;
            return null;
        }

        public class OverflowException : InvalidOperationException
        {
        }

        public class UnderflowException : InvalidOperationException
        {
        }

        public class IllegalCapacityException : InvalidOperationException
        {
        }
    }
}
