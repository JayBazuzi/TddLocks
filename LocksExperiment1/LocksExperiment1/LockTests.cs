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
    }
}
