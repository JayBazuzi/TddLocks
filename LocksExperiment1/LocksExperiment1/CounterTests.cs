﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LocksExperiment1
{
    public class CounterTests
    {
        class MockLock : ILock
        {
            bool acquired = false;
            IDisposable ILock.Acquire()
            {
                this.acquired = true;
                return this;
            }

            bool ILock.IsLocked
            {
                get
                {
                    return this.acquired && !this.disposed;
                }
            }

            bool disposed = false;
            void IDisposable.Dispose()
            {
                this.disposed = true;
            }
        }

        Counter Create()
        {
            return new Counter(new MockLock());
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
