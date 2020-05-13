using System;
using System.Collections;
using System.Collections.Generic;

namespace SetWPF
{
    public class Set<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly List<T> _items = new List<T>();
        public Set()
        {

        }
        public Set(IEnumerable<T> items)
        {
            AddRange(items);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }

        }
        public void Add(T item)
        {
            if (_items.Contains(item))
            {
                throw new ArgumentException();
            }
            _items.Add(item);
        }
        public void AddWhichDontExist(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                AddItemWhichDontExists(item);
            }
        }

        private void AddItemWhichDontExists(T item)
        {
            if (_items.Contains(item))
            {
                return; 
            }
            _items.Add(item);
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }
        public void Clear()
        {
            _items.Clear();
        }
        public Set<T> Union(Set<T> other)
        {
            Set<T> set = new Set<T>();
            AddWhichDontExist(other._items);
            set._items.AddRange(_items);
            return set;
        }
        public Set<T> Intersection(Set<T> other)
        {
            Set<T> result = new Set<T>();
            foreach (var item in _items)
            {
                if (other._items.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public Set<T> Difference(Set<T> other)
        {
            Set<T> result = new Set<T>(_items);
            foreach (var item in other._items)
            {
                result.Remove(item);
            }
            return result;
        }
        public Set<T> SymmetricDifference(Set<T> other)
        {
            Set<T> intersection = Intersection(other);
            Set<T> union = Union(other);
            return union.Difference(intersection);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
