using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocksExperiment1
{
    /// <summary>
    /// A trivial implementation of `ILock`, which only works on one thread.
    /// </summary>
    class SingleThreadedLock : IDisposable, ILock
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
