using System;

namespace DelegatesAndEvents
{
    public class Program
    {
        public delegate int BizRulesDelegate(int x, int y);

        public enum WorkType
        {
            GoToMeetings,
            Golf,
            GenerateReports
        }

        static void Main(string[] args)
        {
            // non-standard
            WorkPerformedHandlerWithEventArgs del1 = new WorkPerformedHandlerWithEventArgs(WorkPerformed1);
            WorkPerformedHandlerWithouEventArgs del2 = new WorkPerformedHandlerWithouEventArgs(WorkPerformed2);
            WorkPerformedHandlerWithouEventArgs del3 = new WorkPerformedHandlerWithouEventArgs(WorkPerformed3);
            WorkPerformedHandlerWithouEventArgs del4 = new WorkPerformedHandlerWithouEventArgs(WorkPerformed4);

            // multicast through invocation list
            del2 += del3 + del4;

            // invoking method through delegate (method passed through the handler's constructor)
            del2(10, WorkType.GenerateReports);

            Worker worker = new Worker();

            // wire up the event (creating an instance of the delegate and attaching it to an event
            // data comes along the pipeline and is dumped into the handler method
            // the += operator is used to attach an event to an event handler
            // the pipeline (or delegate) is being registered with the WorkedPerformed delegate and added into the invocation list
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkPerformed1);
            worker.WorkCompleted += new EventHandler(WorkCompleted);

            worker.DoWork(10, WorkType.GenerateReports);

            /*** Delegate Inference ***/
            // instead of...
            // worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkedPerformed1);

            // do this instead by allowing the compiler to infer the delegate since types are already defined in the worker
            // type "+=" then double tab
            worker.WorkPerformed += Worker_WorkPerformed;

            /*** Anonymous methods ***/
            worker.WorkPerformed += delegate(object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine("Anonymous method.");
            };

            /*** Lambda expressions ***/
            // Simplify the anonymous method above with a lambda expression if its simple code
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("Lambda expression.");
            };

            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;

            var data = new ProcessData();
            data.Process(2, 3, addDel);
            data.Process(2, 3, multiplyDel);

            /*** Custom .NET delegates ***/
            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x * y);
            data.ProcessAction(2, 3, myAction);
            data.ProcessAction(2, 3, myMultiplyAction);

            // two ints in, one int out
            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultipleDel = (x, y) => x * y;
            data.ProcessFunc(3, 2, funcAddDel);
            data.ProcessFunc(3, 2, funcMultipleDel);
        }

        static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void WorkPerformed1(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("WorkPerformed1 called " + e.Hours.ToString() + " " + e.WorkType);
        }

        static void WorkPerformed2(int hours, WorkType worktype)
        {
            Console.WriteLine("WorkPerformed2 called " + hours.ToString());
        }

        static void WorkPerformed3(int hours, WorkType workttype)
        {
            Console.WriteLine("WorkPerformed3 called " + hours.ToString());
        }

        static void WorkPerformed4(int hours, WorkType workttype)
        {
            Console.WriteLine("WorkPerformed4 called " + hours.ToString());
        }

        static void WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Worker is done");
        }
    }
}
