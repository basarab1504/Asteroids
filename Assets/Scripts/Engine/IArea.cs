using System;
using System.Collections.Generic;

namespace Asteroids
{
    public interface IArea
    {
        Coordinates3D Size { get; }
    }
}