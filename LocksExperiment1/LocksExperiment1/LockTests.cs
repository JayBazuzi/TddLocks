using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LocksExperiment1
{
    public class LockTests
    {
        [Fact]
        void CanCreateLock()
        {
            new Lock();
        }

        [Fact]
        void LockedLockShouldBeLocked()
        {
            var @lock = new Lock();

            Assert.False(@lock.IsLocked);
            @lock.Acquire();
            Assert.True(@lock.IsLocked);
        }

        [Fact]
        void CanReleaseLock()
        {
            var @lock = new Lock();

            @lock.Acquire();
            @lock.Release();

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
        void DisposableLock()
        {
            var @lock = new Lock();

            using (@lock.Acquire())
            {
                Assert.True(@lock.IsLocked);
            }
            Assert.False(@lock.IsLocked);
        }
    }
}
