using System;
using System.Collections.Generic;
using System.Text;
using static DelegatesAndEvents.Program;

namespace DelegatesAndEvents
{
    // non-standard
    // public delegate void WorkedPerformedHandler(int hours, WorkType workType);
    // public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

    public class Worker
    {
        // defining two custom events

        // we can eliminate the delegate altogether with EventHandler<T>
        // public event WorkPerformedHandler WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType worktype)
        {
            for (int i = 0; i < hours; i++)
            {
                // raise event
                // WorkPerformed(hours, worktype); (not recommended)

                OnWorkedPerformed(hours, worktype);
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
            // access underlying delegate from the event
            // WorkedPerformedHandler del = WorkPerformed as WorkedPerformedHandler;
            // if (del != null) // listeners are attached
            // {
            //     del(hours, worktype); // raise event
            // }

            // or invoke the event directly ...

            if (WorkPerformed != null)
            {
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
