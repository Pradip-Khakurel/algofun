using System.Numerics;
using NUnit.Framework;

namespace AlgoFun.Tests.DivideAndConquer
{
    public class RecursiveIntegerMultiplicationTest
    {
        [TestCase("3", "2", "6")]
        [TestCase("10", "10", "100")]
        [TestCase("5678", "1234", "7006652")]
        [TestCase("3141592653589793238462643383279502884197169399375105820974944592", "2718281828459045235360287471352662497757247093699959574966967627", "8539734222673567065463550869546574495034888535765114961879601127067743044893204848617875072216249073013374895871952806582723184")]
        public void TestMultiply(string x, string y, string expected)
        {
            var rec = new RecursiveIntegerMultiplication();
            var test = rec.Multiply(x, y);

            Assert.That(test, Is.EqualTo(expected));
        }
    }
}