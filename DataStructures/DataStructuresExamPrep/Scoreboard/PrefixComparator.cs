namespace Scoreboard
{
    using System;
    using System.Collections.Generic;
    class PrefixComparator : Comparer<string>
    {
        public override int Compare(string x, string y)
        {
            //ab
            //bb
            int maxLength = Math.Min(x.Length, y.Length);
            for (int i = 0; i < maxLength; i++)
            {
                if (x[i] > y[i])
                {
                    return 1;
                }
                else if (x[i] < y[i])
                {
                    return -1;
                }
            }
            return x.Length.CompareTo(y.Length);
        }
    }
}
