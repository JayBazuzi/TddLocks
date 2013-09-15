using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocksExperiment1
{
    public class SingleThreadedLockTests : LockTests
    {
        protected override ILock Create()
        {
            return new SingleThreadedLock();
        }
    }
}
