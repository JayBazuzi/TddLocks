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
        Counter Create()
        {
            return new Counter() ;
        }

        [Fact]
        public void CanCreateCounter()
        {
            var counter = Create();
        }

        [Fact]
        public void CounterShouldStartAtZeor()
        {
            var counter = Create();
            var result = counter.GetValue();
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountShouldCount()
        {
            var counter = Create();
            counter.GetValue();
            var result = counter.GetValue();
            Assert.Equal(1, result);
        }
    }
}
