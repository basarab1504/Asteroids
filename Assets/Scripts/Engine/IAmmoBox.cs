using System;
using System.Collections.Generic;

namespace Asteroids
{
    public interface IAmmoBox
    {
        int Capacity { get; }
        // IEnumerable<IAmmo> Ammos { get; }
        IAmmo GetAmmo();
        // void Reload();
    }
}