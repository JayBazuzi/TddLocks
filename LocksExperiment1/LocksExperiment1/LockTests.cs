using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LocksExperiment1
{
    public abstract class LockTests
    {
        protected abstract ILock Create();

        [Fact]
        public void CanCreateLock()
        {
            Create();
        }

        [Fact]
        public void LockedLockShouldBeLocked()
        {
            var @lock = Create();

            Assert.False(@lock.IsLocked);
            @lock.Acquire();
            Assert.True(@lock.IsLocked);
        }

        [Fact]
        public void CanReleaseLock()
        {
            var @lock = Create();

            var token = @lock.Acquire();
            token.Dispose();

            Assert.False(@lock.IsLocked);
        }

        // a convenient pattern that lets you replace:
        //
        //      lock (_syncObject)
        //      {
        //          // ...
        //      }
        //
        // with
        //
        //      using (_lock.Acquire())
        //      {
        //          // ...
        //      }
        [Fact]
        public void DisposableLock()
        {
            var @lock = Create();

            using (@lock.Acquire())
            {
                Assert.True(@lock.IsLocked);
            }

            Assert.False(@lock.IsLocked);
        }
    }
}
