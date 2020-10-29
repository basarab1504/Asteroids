using System;
using System.Collections.Generic;

namespace Asteroids
{
    public interface IPool
    {
        IEnumerable<IPoolable> Poolables { get; }
    }
}