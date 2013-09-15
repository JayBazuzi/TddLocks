using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocksExperiment1
{
    class Lock
    {
        public IDisposable Acquire()
        {
            this.IsLocked = true;
            return null;
        }

        public bool IsLocked { get; private set; }

        internal void Release()
        {
            this.IsLocked = false;
        }
    }
}
