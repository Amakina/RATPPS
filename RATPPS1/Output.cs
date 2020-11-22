using System;
using System.Collections.Generic;
using System.Linq;

namespace RATPPS1
{
    public class Output
    {
        public decimal SumResult { get; set; }
        public int MulResult { get; set; }
        public decimal[] SortedInputs { get; set; }

        public Output() { }

        public Output(Input input)
        {
            SumResult = 0;
            MulResult = 1;
            SortedInputs = new decimal[input.Muls.Length + input.Sums.Length];

            var i = 0;

            foreach (var n in input.Sums)
            {
                SumResult += n;
                SortedInputs[i] = n;
                i++;
            }
            SumResult *= input.K;

            foreach (var n in input.Muls)
            {
                MulResult *= n;
                SortedInputs[i] = n;
                i++;
            }

            Array.Sort(SortedInputs);

        }

        public override bool Equals(object obj)
        {
            var another = obj as Output;
            if (another == null) return false;

            return SumResult == another.SumResult
                && MulResult == another.MulResult
                && SortedInputs != null && another.SortedInputs != null 
                && SortedInputs.Length == another.SortedInputs.Length
                && SortedInputs.SequenceEqual(another.SortedInputs);
        }

        public override int GetHashCode()
        {
            var hashCode = -39567506;
            hashCode = hashCode * -1521134295 + SumResult.GetHashCode();
            hashCode = hashCode * -1521134295 + MulResult.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<decimal[]>.Default.GetHashCode(SortedInputs);
            return hashCode;
        }
    }
}
