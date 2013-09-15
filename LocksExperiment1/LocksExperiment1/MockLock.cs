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
            this.OnAcquire(this, this.obj);
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
            this.OnDispose(this, this.obj);
            this.disposed = true;
        }

        T obj;
        internal void SetObject(T obj)
        {
            this.obj = obj;
        }
    }
}
