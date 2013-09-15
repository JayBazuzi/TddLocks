using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocksExperiment1
{
    class Counter
    {
        readonly object _syncRoot = new object();

        int i = 0;

        internal int GetValue()
        {
            lock (_syncRoot)
            {
                return i++;
            }
        }
    }
}
