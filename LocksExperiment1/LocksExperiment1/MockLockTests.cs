using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocksExperiment1
{
    public class MockLockTests : LockTests
    {
        protected override ILock Create()
        {
            return new MockLock<Counter>();
        }
    }
}
