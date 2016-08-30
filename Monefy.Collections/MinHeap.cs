using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace Monefy.Collections
{
    public class MinHeap<T>
    {
        private const int _defaultCapacity = 4;
        private static T[] _emptyArray = new T[0];
        private T[] _items;
        [ContractPublicPropertyName("Count")]
        private int _size;
        private int _version;
        private IComparer<T> _comparer;

        public MinHeap()
        {
            if (!IsIComparableImplemented()) throw new InvalidOperationException(SR.InvalidOperation_NeedIComparableImplemented);
            Contract.EndContractBlock();

            _comparer = Comparer<T>.Default;

            _items = _emptyArray;
        }



        public MinHeap(IComparer<T> comparer)
        {
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));
            Contract.EndContractBlock();

            _items = _emptyArray;
        }

        private static bool IsIComparableImplemented()
        {
            return typeof(IComparable<T>).GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo());
        }

        public MinHeap(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), capacity, SR.ArgumentOutOfRange_NeedNonNegNum);
            if (!IsIComparableImplemented()) throw new InvalidOperationException(SR.InvalidOperation_NeedIComparableImplemented);
            Contract.EndContractBlock();

            _comparer = Comparer<T>.Default;

            InitializeWithCapacity(capacity);
        }

        public MinHeap(int capacity, IComparer<T> comparer)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), capacity, SR.ArgumentOutOfRange_NeedNonNegNum);
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));
            Contract.EndContractBlock();

            _comparer = comparer;

            InitializeWithCapacity(capacity);
        }

        private void InitializeWithCapacity(int capacity)
        {
            if (capacity == 0)
            {
                _items = _emptyArray;
            }
            else
            {
                _items = new T[capacity];
            }
        }

        public MinHeap(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (!IsIComparableImplemented()) throw new InvalidOperationException(SR.InvalidOperation_NeedIComparableImplemented);
            Contract.EndContractBlock();

            _comparer = Comparer<T>.Default;

            Hipify(collection);
        }

        public MinHeap(IEnumerable<T> collection, IComparer<T> comparer)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));
            Contract.EndContractBlock();

            _comparer = comparer;
            Hipify(collection);
        }

        private void Hipify(IEnumerable<T> collection)
        {
            ICollection<T> c = collection as ICollection<T>;
            if (c != null)
            {
                int count = c.Count;
                if (count == 0)
                {
                    _items = _emptyArray;
                }
                else
                {
                    _items = new T[count];
                    c.CopyTo(_items, 0);
                    _size = count;
                }
            }
            else
            {
                _size = 0;
                _items = _emptyArray;

                using (IEnumerator<T> en = collection.GetEnumerator())
                {
                    while (en.MoveNext())
                    {
                        Add(en.Current);
                    }
                }
            }
        }

        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            //add new element to the end of the array

            EnsureCapacity();

            _items[_size++] = item;

            BubleUp(_size - 1);
        }

        protected void BubleUp(int index)
        {
            while (index > 0)
            {
                int parent = index / 2;
                //If added item is less then it's parent they should be swaped
                if(_comparer.Compare(_items[index], _items[parent]) < 0)
                {
                    T temp = _items[index];
                    _items[index] = _items[parent];
                    _items[parent] = temp;
                }else
                {
                    break;
                }

                index = parent;
            }
        }

        private void EnsureCapacity()
        {
            if(_size == _items.Length)
            {
                if(_size == 0)
                {
                    Capacity = _defaultCapacity;
                }else
                {
                    Capacity = _items.Length * 2;
                }
            }
        }

        public T PeekMin()
        {
            if (_size == 0) throw new InvalidOperationException(SR.InvalidOperation_EmptyHeap);
            return _items[0];
        }

        public int Capacity 
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value < _size) throw new ArgumentOutOfRangeException(nameof(value), value, SR.ArgumentOutOfRange_SmallCapacity);
                Contract.EndContractBlock();

                if(value != _items.Length)
                {
                    if(value > 0)
                    {
                        T[] items = new T[value];
                        Array.Copy(_items, 0, items, 0, _size);
                        _items = items;
                    }
                    else
                    {
                        _items = _emptyArray;
                    }
                }
            }
        }
    }
}
