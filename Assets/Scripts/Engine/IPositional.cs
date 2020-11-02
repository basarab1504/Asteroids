using System;
using System.Collections.Generic;

namespace Asteroids
{
    public interface IPositional
    {
        Coordinates3D Position { get; set; }
    }
}