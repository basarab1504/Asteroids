using System;
using System.Collections.Generic;

namespace Asteroids
{
    public interface IPool<T> where T : IPoolable
    {
        IEnumerable<T> Poolables { get; }
        T GetPoolable();
        // void Release(T poolable);
    }
}