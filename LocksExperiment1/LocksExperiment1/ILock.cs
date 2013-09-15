using System;
namespace LocksExperiment1
{
    interface ILock : IDisposable
    {
        IDisposable Acquire();

        bool IsLocked { get; }
    }
}
