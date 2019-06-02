using System;
using System.Collections.Generic;

namespace Task2
{
    class Segment : IComparable<Segment>, IComparer<Segment>
    {
        public int Len { get; set; }
        public int Num { get; set; } = 1;
        public Segment() { }
        public Segment(int len, int num)
        {
            Len = len;
            Num = num;
        }
        public Segment(int len)
        {
            Len = len;
        }
        public int CompareTo(Segment segment)
        {
            if (Len == segment.Len)
            {
                return 0;
            }
            else if (Len > segment.Len)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public int Compare(Segment x, Segment y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return 1;
            }
            if (y == null)
            {
                return -1;
            }
            return -(x.Num.CompareTo(y.Num));
        }
        public override string ToString()
        {
            return (Len + ";" + Num);
        }
    }
}
