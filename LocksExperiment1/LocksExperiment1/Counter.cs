using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocksExperiment1
{
    class Counter
    {
        readonly ILock @lock;

        public Counter(ILock @lock)
        {
            this.@lock = @lock;
        }

        int i = 0;

        internal int GetValue()
        {
            return i++;
        }
    }
}
