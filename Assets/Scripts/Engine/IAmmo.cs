using System;

namespace Asteroids
{
    public interface IAmmo : IDestroyable
    {
        void Shoot(Coordinates3D direction, float force);
    }
}
