using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace AlgoFun
{
    public class RecursiveIntegerMultiplication
    {
        public string Multiply(string x, string y)
        {
            if (x.Length < 9 && y.Length < 9)
                return (long.Parse(x) * long.Parse(y)).ToString();

            var n = Math.Max(x.Length, y.Length);
            x = AddZerosLeft(x, n - x.Length);
            y = AddZerosLeft(y, n - y.Length);

            var a = x.Substring(0, n / 2);
            var b = x.Substring(n / 2, n - n / 2);
            var c = y.Substring(0, n / 2);
            var d = y.Substring(n / 2, n - n / 2);

            var ac = Multiply(a, c);
            var bd = Multiply(b, d);
            var ad = Multiply(a, d);
            var bc = Multiply(b, c);

            return Add(Add(AddZerosRight(ac, n), AddZerosRight(Add(ad, bc), n / 2)), bd);
        }

        private string AddZerosRight(string s, int n)
        {
            var builder = new StringBuilder(s);
            for (int i = 0; i < n; i++) builder.Append("0");
            return builder.ToString();
        }

        private string AddZerosLeft(string s, int n)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < n; i++) builder.Append("0");
            builder.Append(s);
            return builder.ToString();
        }

        private string Add(string x, string y)
        {
            int i = x.Length - 1, j = y.Length - 1, carry = 0;

            var stack = new Stack<string>();

            while (j >= 0 || i >= 0)
            {
                var left = i < 0 ? 0 : (int)char.GetNumericValue(x[i]);
                var right = j < 0 ? 0 : (int)char.GetNumericValue(y[j]);
                var sum = left + right + carry;

                carry = sum / 10;
                stack.Push((sum % 10).ToString());

                i--;
                j--;
            }

            if (carry > 0) stack.Push(carry.ToString());

            return new string(stack.Select(s => s[0]).ToArray());
        }
    }
}
