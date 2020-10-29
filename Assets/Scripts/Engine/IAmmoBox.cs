using System;
using System.Collections.Generic;

namespace Asteroids
{
    public interface IAmmoBox
    {
        IEnumerable<IAmmo> Ammos { get; }
        void Reload();
    }
}