using System;
using System.Collections.Generic;
using System.Linq;

namespace RATPPS1
{
    public class Input
    {
        public int K { get; set; }
        public decimal[] Sums { get; set; }
        public int[] Muls { get; set; }

        public override bool Equals(object obj)
        {
            var another = obj as Input;
            return K == another.K
                && Sums != null && another.Sums != null
                && Sums.Length == another.Sums.Length && Sums.SequenceEqual(another.Sums) 
                && Muls != null && another.Muls != null
                && Muls.Length == another.Muls.Length && Muls.SequenceEqual(another.Muls);
        }

        public override int GetHashCode()
        {
            var hashCode = -1724030135;
            hashCode = hashCode * -1521134295 + K.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<decimal[]>.Default.GetHashCode(Sums);
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(Muls);
            return hashCode;
        }
    }
}
