using System;
using System.Collections.Generic;
using System.Text;
using static DelegatesAndEvents.Program;

namespace DelegatesAndEvents
{
    public class ProcessData
    {
        // the delegate allows us to decouple the business rules from the Process() method
        public void Process(int x, int y, BizRulesDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine(result);
        }

        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
            Console.WriteLine("Action has been processed");
        }

        public void ProcessFunc(int x, int y, Func<int, int, int> func)
        {
            var result = func(x, y);
            Console.WriteLine(result);
        }
    }
}
