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
            @lock.Lock();

            var result = @lock.IsLocked;

            Assert.True(result.IsLocked);
        }
    }
}
