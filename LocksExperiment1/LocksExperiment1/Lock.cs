using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocksExperiment1
{
    class Lock
    {
        public void Acquire()
        {
            this.IsLocked = true;
        }

        public bool IsLocked;

        internal void Release()
        {
            this.IsLocked = false;
        }
    }
}
