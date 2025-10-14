using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo.Bussisness
{
    public class Collection<T> 
    {
        private T[] _elements;
        private int _index;
        private int _size;
        public Collection(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Size must be greater than 0");
            }
            _size = size;
            _elements = new T[_size];
            _index = 0;
        }

        public void Add(T element)
        {
            if (_index >= _size)
            {
                throw new InvalidOperationException("Collection is full");
            }
            _elements[_index] = element;
            _index++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new ArgumentOutOfRangeException("Index must be between 0 and size-1");
            }
            return _elements[index];
        }
        public T[] GetAll()
        {
            return _elements;
        }
    }
}
