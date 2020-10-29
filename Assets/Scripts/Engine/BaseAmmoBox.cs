using System;
using System.Collections.Generic;

namespace Asteroids
{
    public abstract class BaseAmmoBox : IAmmoBox
    {
        private int capacity;
        private List<IAmmo> ammos;

        public BaseAmmoBox(int capacity)
        {
            this.capacity = capacity;
        }

        public IEnumerable<IAmmo> Ammos => ammos;

        public abstract void Reload();
    }
}