﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStructures
{
    /// <summary>
    /// Integer List
    /// </summary>
    public class CustomList<T> where T : IComparable
    {
        /// <summary>
        /// Default size of internal array
        /// </summary>
        private const int defaultSize = 2;

        /// <summary>
        /// Internal array
        /// </summary>
        private T[] innerArr;

        /// <summary>
        /// Number of elements int he list 
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Creates custom integer list with defaut size
        /// </summary>
        public CustomList()
        {
            innerArr = new T[defaultSize];
        }

        /// <summary>
        /// Creates custom integer list with defaut size
        /// </summary>
        /// <param name="initialSize">Initial size of the list </param>
        public CustomList(int initialSize)
        {
            innerArr = new T[initialSize];
        }

        public T this[int index]
        {
            get
            {
                CheckIndexRamge(index);
                return innerArr[index];
            }

            set
            {
                CheckIndexRamge(index);
                innerArr[index] = value;
            }
        }

        public void Add(T element)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            innerArr[Count] = element;
            Count++;
        }

        public void AddRange(T[] list)
        {
            if (list.Length + Count >= innerArr.Length)
            {
                if (list.Length + Count > innerArr.Length * 2)
                {
                    Grow(list.Length + Count);
                }
                else
                {
                    Grow();
                }
            }

            for (int i = 0; i < list.Length; i++)
            {
                innerArr[Count] = list[i];
                Count++;
            }
        }

        /// <summary>
        /// Removes element at position
        /// </summary>
        /// <param name="index">position</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void RemoveAt(int index)
        {
            CheckIndexRamge(index);
            ShiftLeft(index);
            Count--;
            Shrink();
        }

        public void InsertAt(int index, T element)
        {
            CheckIndexRamge(index);
            ShiftRight(index);
            innerArr[index] = element;
            Count++;
        }

        public bool Contains(T element)
        {
            bool result = false;

            foreach (var item in innerArr)
            {
                if (item.CompareTo(element) == 0)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIndexRamge(firstIndex);
            CheckIndexRamge(secondIndex);

            T tempElement = innerArr[firstIndex];

            innerArr[firstIndex] = innerArr[secondIndex];
            innerArr[secondIndex] = tempElement;
        }

        public void Shrink()
        {
            if (innerArr.Length / 4 > Count)
            {
                T[] tempArr = new T[innerArr.Length / 2];

                for (int i = 0; i < Count; i++)
                {
                    tempArr[i] = innerArr[i];
                }

                innerArr = tempArr;
            }
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(innerArr[i]);
            }
        }


        #region private
        private void ShiftRight(int position)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            for (int i = Count - 1; i >= position; i--)
            {
                innerArr[i + 1] = innerArr[i];
            }
            innerArr[position] = default;
        }

        private void Grow()
        {
            Grow(innerArr.Length * 2);
        }

        private void Grow(int newSize)
        {
            T[] tempArr = new T[innerArr.Length * newSize];

            innerArr.CopyTo(tempArr, 0);
            innerArr = tempArr;
        }

        private void ShiftLeft(int position)
        {
            if (position < Count - 1)
            {
                for (int i = position; i < Count - 1; i++)
                {
                    innerArr[i] = innerArr[position + 1];
                }

                innerArr[Count - 1] = default;
            }

            innerArr[position] = default;
        }

        private void CheckIndexRamge(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        #endregion
    }
}
