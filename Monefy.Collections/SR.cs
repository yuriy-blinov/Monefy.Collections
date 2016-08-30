using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Collections
{
    internal class SR
    {
        internal static string ArgumentOutOfRange_NeedNonNegNum = "Non-negative number required.";
        internal static string InvalidOperation_NeedIComparableImplemented = "IComparable should be implemented.";

        public static string InvalidOperation_EmptyHeap = "Heap is empty.";

        public static string ArgumentOutOfRange_SmallCapacity = "Capacity was less than the current size.";
    }
}
