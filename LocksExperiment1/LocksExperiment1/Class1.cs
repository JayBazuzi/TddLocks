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
            var counter = new Counter();
        }

        [Fact]
        public void CounterShouldStartAtZeor()
        {
            var counter = new Counter();
            var result = counter.GetValue();
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountShouldCount()
        {
            var counter = new Counter();
            counter.GetValue();
            var result = counter.GetValue();
            Assert.Equal(1, result);
        }
    }
}
