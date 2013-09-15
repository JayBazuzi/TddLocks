using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocksExperiment1
{
    class MyLock
    {
        public void Lock()
        {
            this.IsLocked = true;
        }

        public bool IsLocked;
    }
}
