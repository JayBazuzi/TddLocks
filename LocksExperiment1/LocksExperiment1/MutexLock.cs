using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LocksExperiment1
{
    class MutexLock : ILock
    {
        readonly Mutex mutex = new Mutex(false);

        IDisposable ILock.Acquire()
        {
            this.mutex.WaitOne();
            this._isLocked = true;
            return this;
        }

        bool _isLocked;
        bool ILock.IsLocked { get { return this._isLocked; } }

        void IDisposable.Dispose()
        {
            this._isLocked = false;
            this.mutex.ReleaseMutex();
        }

        public ILock ILock { get { return this; } }
    }
}
