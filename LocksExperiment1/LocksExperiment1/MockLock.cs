using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocksExperiment1
{
    class MockLock<T> : ILock
    {
        public event EventHandler<T> OnAcquire = delegate { };
        bool acquired = false;

        IDisposable ILock.Acquire()
        {
            this.OnAcquire(this, this.counter);
            this.acquired = true;
            return this;
        }

        bool ILock.IsLocked
        {
            get
            {
                return this.acquired && !this.disposed;
            }
        }

        public event EventHandler<T> OnDispose = delegate { };
        bool disposed = false;
        void IDisposable.Dispose()
        {
            this.OnDispose(this, this.counter);
            this.disposed = true;
        }

        T counter;
        internal void SetCounter(T counter)
        {
            this.counter = counter;
        }
    }
}
