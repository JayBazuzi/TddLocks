using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LocksExperiment1
{
    public class CounterTests
    {
        class MockLock : ILock
        {
            public event EventHandler<Counter> OnAcquire = delegate { };
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

            public event EventHandler<Counter> OnDispose = delegate { };
            bool disposed = false;
            void IDisposable.Dispose()
            {
                this.OnDispose(this, this.counter);
                this.disposed = true;
            }

            Counter counter;
            internal void SetCounter(Counter counter)
            {
                this.counter = counter;
            }
        }

        public class MockLockTests : LockTests
        {
            protected override ILock Create()
            {
                return new MockLock();
            }
        }


        Counter Create()
        {
            var counter = new Counter(this.mockLock);
            this.mockLock.SetCounter(counter);
            return counter;
        }

        MockLock mockLock = new MockLock();

        [Fact]
        public void CanCreateCounter()
        {
            var counter = Create();
        }

        [Fact]
        public void CounterShouldStartAtZeor()
        {
            var counter = Create();
            var result = counter.GetValue();
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountShouldCount()
        {
            var counter = Create();
            counter.GetValue();
            var result = counter.GetValue();
            Assert.Equal(1, result);
        }

        [Fact]
        public void CounterShouldLockAroundChange()
        {
            var counter = Create();

            this.mockLock.OnAcquire += (sender, eventArgs) => Assert.Equal(0, eventArgs.CurrentValue);
            this.mockLock.OnDispose += (sender, eventArgs) => Assert.Equal(1, eventArgs.CurrentValue);
            counter.GetValue();
        }
    }
}
