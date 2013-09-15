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
            Monitor.Enter(_syncLock, ref isLocked);
            return this;
        }

        bool ILock.IsLocked
        {
            get
            {
                return Monitor.IsEntered(this._syncLock);
            }
        }

        void IDisposable.Dispose()
        {
            if (isLocked) Monitor.Exit(_syncLock);
        }
    }
}
