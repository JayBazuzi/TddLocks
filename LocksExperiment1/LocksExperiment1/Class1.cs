using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LocksExperiment1
{
    public class CounterTests
    {
        [Fact]
        public void CanCreateCounter()
        {
            new Counter();
        }
    }
}
