using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AlgoFun.Greedy;
using System.IO;

namespace AlgoFun.Tests.Greedy
{
    [TestFixture]
    public class WrongSchedulerTest
    {
        [Test]
        public void TestOneWrong() 
        {
            var actual = new JobScheduler().ScheduleWrong(GetTestOne());
            var expected = 15*1 + 20*11 + 5*16;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestFileWrong() 
        {
            var actual = new JobScheduler().ScheduleWrong(GetTestFile());
        }

        [Test]
        public void TestOneRight() 
        {
            var actual = new JobScheduler().ScheduleRight(GetTestOne());
            var expected = 15*1 + 20*11 + 5*16;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestFileRight()
        {
            var actual = new JobScheduler().ScheduleRight(GetTestFile());
        }


        private IEnumerable<Job> GetTestOne() 
        {
            return new [] 
            { 
                new Job() 
                { 
                    Weight = 20,
                    Length = 10,
                },
                new Job () 
                {
                    Weight = 15,
                    Length = 1
                },
                new Job() 
                {
                    Weight = 5,
                    Length = 5,
                }
            };
        }

        private IEnumerable<Job> GetTestFile() 
        {
            var lines = File.ReadAllLines("jobs.txt");
            var jobs = new List<Job>();

            foreach (var ln in lines)
            {
                var split = ln.Split(" ");
                jobs.Add(new Job() 
                {
                    Weight = double.Parse(split[0]),
                    Length = double.Parse(split[1])
                });
            }

            return jobs;
        }
    }
}
