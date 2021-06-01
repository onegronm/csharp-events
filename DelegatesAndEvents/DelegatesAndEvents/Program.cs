using System;

namespace DelegatesAndEvents
{
    public class Program
    {
        public enum WorkType
        {
            GoToMeetings,
            Golf,
            GenerateReports
        }

        static void Main(string[] args)
        {
            //WorkedPerformedHandler del1 = new WorkedPerformedHandler(WorkedPerformed1);
            //WorkedPerformedHandler del2 = new WorkedPerformedHandler(WorkedPerformed2);
            //WorkedPerformedHandler del3 = new WorkedPerformedHandler(WorkedPerformed3);

            // multicast through invocation list
            // del1 += del2 + del3;

            // del1(10, WorkType.GenerateReports);
            // DoWork(del1);

            Worker worker = new Worker();
            worker.DoWork(10, WorkType.GenerateReports);
        }

        static void WorkedPerformed1(int hours, WorkType worktype)
        {
            Console.WriteLine("WorkedPerformed1 called " + hours.ToString());
        }

        static void WorkedPerformed2(int hours, WorkType worktype)
        {
            Console.WriteLine("WorkedPerformed2 called " + hours.ToString());
        }

        static void WorkedPerformed3(int hours, WorkType workttype)
        {
            Console.WriteLine("WorkedPerformed3 called " + hours.ToString());
        }
    }
}
