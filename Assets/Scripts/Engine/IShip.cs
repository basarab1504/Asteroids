using System;
using System.Collections.Generic;

namespace Asteroids
{
    public interface IShip : IMovable, IDestroyable
    {
        IEnumerable<IGun> Guns { get; }
        void Shoot(Coordinates3D direction);
    }
}

