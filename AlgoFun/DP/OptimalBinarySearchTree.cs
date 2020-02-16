using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgoFun.DP
{
    public class OptimalBinarySearchTree
    {
        public double Compute(double[] values)
        {
            var n = values.Length;
            var dp = new double[n, n];

            for (int l = 0; l < n; l++)
            {
                for (int i = 0; i < n-l; i++)
                {
                    var min = double.MaxValue;
                    var sum = 0d;

                    for (int k = i; k <= i + l; k++)
                    {
                        sum += values[k];
                    }

                    for (int r = i; r <= i + l; r++)
                    {
                        var left = r == i ? 0d : dp[i, r - 1];
                        var right = r == i + l ? 0d : dp[r + 1, i + l];

                        min = Math.Min(min, left + right);
                    }

                    dp[i, i+l] = min + sum;
                }
            }

            return dp[0, n - 1];
        }
    }
}