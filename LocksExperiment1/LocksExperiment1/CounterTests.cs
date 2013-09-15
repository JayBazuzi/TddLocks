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
            var counter = new Counter(this.mockLock);
            this.mockLock.SetObject(counter);
            return counter;
        }

        MockLock<Counter> mockLock = new MockLock<Counter>();

        [Fact]
        public void CanCreateCounter()
        {
            var counter = Create();
        }

        [Fact]
        public void CounterShouldStartAtZeor()
        {
            var counter = Create();
            var result = counter.MoveNext();
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountShouldCount()
        {
            var counter = Create();
            counter.MoveNext();
            var result = counter.MoveNext();
            Assert.Equal(1, result);
        }

        [Fact]
        public void CounterShouldLockAroundChange()
        {
            var counter = Create();

            this.mockLock.OnAcquire += (sender, eventArgs) => Assert.Equal(0, eventArgs.CurrentValue);
            this.mockLock.OnDispose += (sender, eventArgs) => Assert.Equal(1, eventArgs.CurrentValue);
            counter.MoveNext();
        }
    }
}
