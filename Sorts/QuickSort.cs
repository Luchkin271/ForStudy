using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForStady.Sorts
{
    internal class QuickSort<T> : ISortingClasses
    {
        public T[] Sort<T>(T[] values) where T : IComparable
        {
            return Sort(values, 0, values.Length-1);
        }
        private T[] Sort<T>(T[] values, long left, long right) where T : IComparable
        {
            if(left < right)
            {
                long pilotIndex = Partition(values, left, right);
                Sort(values, left, pilotIndex - 1);
                Sort(values, pilotIndex + 1, right);
            }
            return values;
        }
        private long Partition<T>(T[] array, long left, long right) where T : IComparable
        {
            T pivot = array[right];
            long i = left - 1;

            for (long j = left; j < right; j++)
            {
                if (array[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }

            Swap(ref array[i + 1], ref array[right]);
            return i + 1;
        }
        private static void Swap<T>(ref T a, ref T b) where T : IComparable
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
