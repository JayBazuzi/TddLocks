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

        internal int MoveNext()
        {
            using (this.@lock.Acquire())
            {
                return CurrentValue++;
            }
        }

        public int CurrentValue { get; private set; }
    }
}
