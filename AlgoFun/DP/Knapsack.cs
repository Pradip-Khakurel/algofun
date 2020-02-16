using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgoFun.DP
{
    public class Knapsack
    {
        public class Item
        {
            public int Value { get; set; }

            public int Weight { get; set; }
        }

        public int Compute(Item[] items, int size)
        {
            if (items == null || items.Length == 0)
            {
                return 0;
            }

            int n = items.Length;
            int[] dp = new int[size + 1];

            for (int i = 1; i <= n; i++)
            {
                var next = new int[size+1];
                var item = items[i - 1];

                for (int j = 1; j <= size; j++)
                {
                    if (j - item.Weight >= 0)
                    {
                        next[j] = Math.Max(dp[j - item.Weight] + item.Value, dp[j]);
                    }
                    else 
                    {
                        next[j] = dp[j];
                    }
                }

                dp = next;
            }

            return dp[size];
        }
    }
}