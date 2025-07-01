using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForStady.Sorts
{
    internal interface ISortingClasses
    {
        public T[] Sort<T>(T[] values) where T : IComparable;
    }
}
