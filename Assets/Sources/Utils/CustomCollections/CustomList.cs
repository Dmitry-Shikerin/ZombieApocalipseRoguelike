using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Sources.Utils.CustomCollections
{
    public class CustomList<T> : ICustomList<T>
    {
        private List<T> _collection = new List<T>();

        public int Count => _collection.Count;

        public T this[int index] => _collection[index];

        public void Add(T item) =>
            _collection.Add(item);

        public bool Remove(T item) =>
            _collection.Remove(item);
        
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