using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LocksExperiment1
{
    class MutexLock : ILock
    {
        bool isLocked = false;

        readonly object _syncLock = new object();

        IDisposable ILock.Acquire()
        {
            System.Threading.Monitor.Enter(_syncLock, ref isLocked);
            return this;
        }

        bool _isLocked;
        bool ILock.IsLocked { get { return this.isLocked; } }

        void IDisposable.Dispose()
        {
            if (isLocked) System.Threading.Monitor.Exit(_syncLock);
            isLocked = false;
        }

        public ILock ILock { get { return this; } }
    }
}
