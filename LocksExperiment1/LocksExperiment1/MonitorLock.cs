using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LocksExperiment1
{
    class MonitorLock : ILock
    {
        bool isLocked = false;

        readonly object _syncLock = new object();

        IDisposableLockToken ILock.Acquire()
        {
            Monitor.Enter(_syncLock, ref isLocked);
            return new DisposableToken(this);
        }

        class DisposableToken : IDisposableLockToken
        {
            readonly MonitorLock monitorLock;

            public DisposableToken(MonitorLock monitorLock)
            {
                this.monitorLock = monitorLock;
            }

            void IDisposable.Dispose()
            {
                if (this.monitorLock.isLocked)
                {
                    Monitor.Exit(this.monitorLock._syncLock);
                }
            }
        }

        bool ILock.IsLocked
        {
            get
            {
                return Monitor.IsEntered(this._syncLock);
            }
        }
    }
}
