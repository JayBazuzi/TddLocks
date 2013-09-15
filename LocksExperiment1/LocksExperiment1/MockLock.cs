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
        DisposableToken disposableToken = null;

        IDisposableLockToken ILock.Acquire()
        {
            this.OnAcquire(this, this.obj);
            return disposableToken = new DisposableToken(this);
        }

        class DisposableToken : IDisposableLockToken
        {
            private MockLock<T> mockLock;

            public DisposableToken(MockLock<T> mockLock)
            {
                this.mockLock = mockLock;
            }

            void IDisposable.Dispose()
            {
                this.mockLock.OnDispose(this, this.mockLock.obj);
                this.mockLock.disposableToken = null;
            }
        }

        bool ILock.IsLocked
        {
            get
            {
                return this.disposableToken != null;
            }
        }

        public event EventHandler<T> OnDispose = delegate { };

        T obj;
        internal void SetObject(T obj)
        {
            this.obj = obj;
        }
    }
}
