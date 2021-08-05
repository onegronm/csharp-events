using System;
using System.Collections.Generic;
using System.Text;
using static DelegatesAndEvents.Program;

namespace DelegatesAndEvents
{
    // non-standard declaration
    public delegate void WorkPerformedHandlerWithEventArgs(object sender, WorkPerformedEventArgs e);
    public delegate void WorkPerformedHandlerWithouEventArgs(int hours, WorkType worktype);

    public class Worker
    {
        // we can eliminate the delegate altogether using EventHandler<T>

        // let's define two custom events
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType worktype)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkedPerformed(i, worktype);
            }

            OnWorkCompleted();
        }

        /// <summary>
        /// A method for every event raised
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="worktype"></param>
        protected virtual void OnWorkedPerformed(int hours, WorkType worktype)
        {
            // method 1: access underlying delegate from the event
            // WorkedPerformedHandler del = WorkPerformed as WorkedPerformedHandler;
            // if (del != null) // listeners are attached
            // {
            //     del(hours, worktype); // raise event
            // }

            // method 2: invoke the event directly
            if (WorkPerformed != null)
            {
                // raise the event
                WorkPerformed(this, new WorkPerformedEventArgs(hours, worktype));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            // access underlying delegate from the event
            var del = WorkCompleted as EventHandler;
            if (del != null) // listeners are attached
            {
                del(this, EventArgs.Empty); // raise event (passing the data down the pipeline)
            }
        }
    }
}
