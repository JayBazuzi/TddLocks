using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocksExperiment1
{
    class Lock : IDisposable
    {
        public IDisposable Acquire()
        {
            this.IsLocked = true;
            return this;
        }

        public bool IsLocked { get; private set; }

        public void Dispose()
        {
            this.IsLocked = false;
        }
    }
}
