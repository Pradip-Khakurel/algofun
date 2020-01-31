using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoFun.Greedy
{
    public class JobScheduler
    {
        public double ScheduleWrong(IEnumerable<Job> jobs) 
        {
            return CostOf(jobs.OrderByDescending(j => j.Weight - j.Length).ThenByDescending(j => j.Weight));
        }

        public double ScheduleRight(IEnumerable<Job> jobs)
        {
            return CostOf(jobs.OrderByDescending(j => j.Weight / j.Length));
        }

        private double CostOf(IEnumerable<Job> jobs)
        {
            double cost = 0;
            double sum = 0;

            foreach (var jb in jobs)
            {
                cost += jb.Length;
                sum += cost * jb.Weight;
            }

            return sum;            
        }
    }
}
