using System;

namespace Asteroids
{
    public interface IGun
    {
        IAmmoBox AmmoBox { get; }
        void Shoot(Coordinates3D direction);
        void Reload();
    }
}