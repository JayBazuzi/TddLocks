using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocksExperiment1
{
    /// <summary>
    /// A trivial implementation of `ILock`, which only works on one thread.
    /// </summary>
    class SingleThreadedLock : ILock
    {
        public IDisposableLockToken Acquire()
        {
            this.IsLocked = true;
            return new DisposableLockToken(this);
        }

        class DisposableLockToken : IDisposableLockToken
        {
            private readonly SingleThreadedLock singleThreadedLock;

            public DisposableLockToken(SingleThreadedLock singleThreadedLock)
            {
                this.singleThreadedLock = singleThreadedLock;
            }
            void IDisposable.Dispose()
            {
                this.singleThreadedLock.IsLocked = false;
            }
        }

        public bool IsLocked { get; private set; }
    }
}
