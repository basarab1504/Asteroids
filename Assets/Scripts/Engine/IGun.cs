using System;

namespace Asteroids
{
    public interface IGun
    {
        IAmmoBox AmmoBox { get; }
        float Force { get; }
        void Shoot(Coordinates3D direction);
        // void Reload();
    }
}