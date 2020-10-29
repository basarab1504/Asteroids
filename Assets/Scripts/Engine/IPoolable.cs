using System;

namespace Asteroids
{
    public interface IPoolable
    {
        bool InUse { get; }
    }
}