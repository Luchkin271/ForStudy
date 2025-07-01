using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForStady.Sorts
{
    internal class BubbleSort<T> : ISortingClasses
    {
        public T[] Sort<T>(T[] values) where T : IComparable
        {
            if (values == null || values.Length == 0)
                throw new Exception("BubbleSort::Sort -> The array is empty or not initialized\n");
            for (long i = 1; i < values.Length; i++)
            {
                for (long j = 1; j < values.Length-i; j++)
                {
                    if (values[j].CompareTo(values[j - 1]) <= 0)
                    {
                        Swap(ref values[j], ref values[j-1]);
                    }
                }
            }
            return values;
        }
        private static void Swap<T>(ref T a, ref T b) where T : IComparable
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
