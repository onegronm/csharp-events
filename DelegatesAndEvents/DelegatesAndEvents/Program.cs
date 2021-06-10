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

            // wire up the event (creating an instance of the delegate and attaching it to an event
            // data comes along the pipeline and is dumped into the handler method
            // the += operator is used to attach an event to an event handler
            // the pipeline (or delegate) is being registered with the WorkedPerformed delegate and added into the invocation list
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkedPerformed1);
            worker.WorkCompleted += new EventHandler(WorkCompleted);

            worker.DoWork(10, WorkType.GenerateReports);

            /*** Delegate Inference ***/
            // instead of...
            // worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkedPerformed1);

            // do this instead by allowing the compiler to infer the delegate since types are already defined in the worker
            // type "+=" then double tab
            worker.WorkPerformed += Worker_WorkPerformed;

            /*** Anonymous methods ***/
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine("Anonymous method.");
            };
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Worker is done");
        }

        static void WorkedPerformed1(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("WorkedPerformed1 called " + e.Hours.ToString() + " " + e.WorkType);
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
