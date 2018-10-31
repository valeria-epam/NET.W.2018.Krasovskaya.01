using System;
using System.Collections.Generic;

namespace Sorting
{
    /// <summary>
    /// Provides methods for sorting arrays.
    /// </summary>
    public static class Sort
    {
        /// <summary>
        /// Sorts the <paramref name="items"/> using Quicksort algorithm.
        /// </summary>
        /// <param name="items">The array to sort.</param>
        public static void QuickSort<T>(this T[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            QuickSort(items, 0, items.Length - 1, Comparer<T>.Default);
        }

        /// <summary>
        /// Sorts the <paramref name="items"/> using Quicksort algorithm.
        /// </summary>
        /// <param name="items">The array to sort.</param>
        /// <param name="comparer">The comparer used to compare array elements.</param>
        public static void QuickSort<T>(this T[] items, IComparer<T> comparer)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            QuickSort(items, 0, items.Length - 1, comparer);
        }

        /// <summary>
        /// Sorts the <paramref name="items"/> using MergeSort algorithm.
        /// </summary>
        /// <param name="items">The array to sort.</param>
        public static void MergeSort<T>(this T[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            MergeSort(items, 0, items.Length - 1, Comparer<T>.Default);
        }

        /// <summary>
        /// Sorts the <paramref name="items"/> using MergeSort algorithm.
        /// </summary>
        /// <param name="items">The array to sort.</param>
        /// <param name="comparer">The comparer used to compare array elements.</param>
        public static void MergeSort<T>(this T[] items, IComparer<T> comparer)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            MergeSort(items, 0, items.Length - 1, comparer);
        }

        private static void QuickSort<T>(T[] items, int firstIndex, int lastIndex, IComparer<T> comparer)
        {
            if (firstIndex < lastIndex)
            {
                int p = Partition(items, firstIndex, lastIndex, comparer);
                QuickSort(items, firstIndex, p - 1, comparer);
                QuickSort(items, p + 1, lastIndex, comparer);
            }
        }

        private static int Partition<T>(T[] items, int firstIndex, int lastIndex, IComparer<T> comparer)
        {
            int middle = ((lastIndex - firstIndex) / 2) + firstIndex;
            Swap(ref items[middle], ref items[lastIndex]);
            int b = firstIndex;
            for (int i = firstIndex; i < lastIndex; i++)
            {
                if (comparer.Compare(items[i], items[lastIndex]) < 0)
                {
                    Swap(ref items[i], ref items[b]);
                    b += 1;
                }
            }

            Swap(ref items[lastIndex], ref items[b]);
            return b;
        }

        private static void Swap<T>(ref T item1, ref T item2)
        {
            T item = item1;
            item1 = item2;
            item2 = item;
        }

        private static void MergeSort<T>(T[] items, int firstIndex, int lastIndex, IComparer<T> comparer)
        {
            if (firstIndex < lastIndex)
            {
                int middleIndex = firstIndex + ((lastIndex - firstIndex) / 2);
                MergeSort(items, firstIndex, middleIndex, comparer);
                MergeSort(items, middleIndex + 1, lastIndex, comparer);
                ArrayMergeSortInPlace(items, firstIndex, middleIndex, lastIndex, comparer);
            }
        }

        private static void ArrayMergeSortInPlace<T>(T[] items, int firstIndex, int middleIndex, int lastIndex, IComparer<T> comparer)
        {
            T[] c = new T[lastIndex - firstIndex + 1];
            for (int k = firstIndex; k < lastIndex + 1; k++)
            {
                c[k - firstIndex] = items[k];
            }

            int i = 0;
            int cm = middleIndex - firstIndex + 1;
            int ch = lastIndex - firstIndex + 1;
            int j = cm;

            for (int k = firstIndex; k < lastIndex + 1; k++)
            {
                if (i >= cm)
                {
                    items[k] = c[j];
                    j += 1;
                }
                else if (j >= ch)
                {
                    items[k] = c[i];
                    i += 1;
                }
                else if (comparer.Compare(c[i], c[j]) <= 0)
                {
                    items[k] = c[i];
                    i += 1;
                }
                else
                {
                    items[k] = c[j];
                    j += 1;
                }
            }
        }
    }
}