using System;
using System.Collections.Generic;

namespace Asteroids
{
    public class BaseGun : IGun
    {
        private float force;
        private BaseAmmoBox ammoBox;

        public IAmmoBox AmmoBox => ammoBox;

        public void Shoot(Coordinates3D direction)
        {
            foreach (var a in ammoBox.Ammos)
                a.Shoot(direction, force);
        }

        public void Reload()
        {
            ammoBox.Reload();
        }
    }
}