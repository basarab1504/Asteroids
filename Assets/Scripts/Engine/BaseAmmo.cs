using System;
using System.Collections.Generic;

namespace Asteroids
{
    public class BaseAmmo : IAmmo
    {
        public void Shoot(Coordinates3D direction, float force) { }
        public void Destroy() { }
    }
}