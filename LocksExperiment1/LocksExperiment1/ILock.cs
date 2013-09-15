using System;
namespace LocksExperiment1
{
    public interface ILock
    {
        IDisposableLockToken Acquire();

        bool IsLocked { get; }
    }
}
