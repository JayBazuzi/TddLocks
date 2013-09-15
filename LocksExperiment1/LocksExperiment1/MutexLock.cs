using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocksExperiment1
{
    class MutexLock : ILock
    {
        IDisposable ILock.Acquire()
        {
            throw new NotImplementedException();
        }

        bool ILock.IsLocked
        {
            get { throw new NotImplementedException(); }
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
