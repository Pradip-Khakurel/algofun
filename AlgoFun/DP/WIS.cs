using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgoFun.DP
{
    public class WIS
    {
        public long[] Compute(long[] values)
        {
            if (values == null) return null;
            if (values.Length == 1) return values;

            return Reconstruct(values, GetSolution(values));
        }

        private long[] GetSolution(long[] values)
        {
            var n = values.Length;
            var dp = new long[n];

            dp[0] = values[0];
            dp[1] = Math.Max(values[0], values[1]);

            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + values[i]);
            }

            return dp;
        }

        private long[] Reconstruct(long[] values, long[] dp)
        {
            var result = new List<long>();
            int i = values.Length-1;
            long prev, prevOfPrev;
            
            while (i >= 0)
            {       
                prev = i >= 1 ? dp[i-1] : 0;
                prevOfPrev = i >= 2 ? dp[i-2] : 0;

                if (prevOfPrev + values[i] > prev)
                {
                    result.Add(i);
                    i -= 2;
                }
                else 
                {
                    i -= 1;
                }
            }

            result.Reverse();

            return result.ToArray();
        }

    }
}
