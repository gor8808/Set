using System;
using System.Collections;
using System.Collections.Generic;

namespace Set
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
                throw new ArgumentException();
            }
            _items.Add(item);
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }
        public int Count
        { get
            {
                return _items.Count;
            }
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
            Set<T> set = new Set<T>();
            foreach (var item in _items)
            {
                if (other._items.Contains(item))
                {
                    set.Add(item);
                }
            }
            return set;
        }
        public Set<T> Difference(Set<T> other)
        {
            Set<T> set = new Set<T>();
            foreach (var item in other)
            {
                if (_items.Contains(item))
                {
                    Remove(item);
                }
            }
            return set;
        }
        public Set<T> SymmetricDifference(Set<T> other)
        {
            Set<T> set = new Set<T>();
            foreach (var item in other)
            {
                if (_items.Contains(item))
                {
                    continue;
                }
                else
                {   
                    _items.Add(item);
                }
            }
            return set;
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
