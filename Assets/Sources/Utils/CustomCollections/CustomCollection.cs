using System;
using System.Collections;
using System.Collections.Generic;

namespace Sources.Utils.CustomCollections
{
    public class CustomCollection<T> : ICustomList<T>
    {
        private List<T> _collection = new List<T>();

        public event Action CountChanged;
        
        public int Count => _collection.Count;

        public T this[int index] => _collection[index];

        public void Add(T item)
        {
            _collection.Add(item);
            CountChanged?.Invoke();
        }

        public bool Remove(T item)
        {
            bool result = _collection.Remove(item);
            CountChanged?.Invoke();
            return result;
        }

        public void Clear() =>
            _collection.Clear();

        public bool Contains(T item) => 
            _collection.Contains(item);
        
        public IEnumerator<T> GetEnumerator() =>
            _collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}