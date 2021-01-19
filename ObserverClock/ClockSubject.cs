using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverClock
{
    public class ClockSubject : Subject
    {
        private DateTime state;

        public DateTime GetState()
        {
            return state;
        }

        public void SetState(DateTime value)
        {
            state = value;
            Notify();
        }
    }
}
