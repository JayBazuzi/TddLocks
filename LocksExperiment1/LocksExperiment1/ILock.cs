using System;
namespace LocksExperiment1
{
    public interface ILock : IDisposable
    {
        IDisposable Acquire();

        bool IsLocked { get; }
    }
}
