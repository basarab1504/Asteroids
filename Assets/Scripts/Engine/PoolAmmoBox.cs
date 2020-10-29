using System;
using System.Collections.Generic;

namespace Asteroids
{
    public class PoolAmmoBox : BaseAmmoBox, IPool
    {
        private List<PoolableAmmo> poolableAmmo;

        public IEnumerable<IPoolable> Poolables => poolableAmmo;

        public PoolAmmoBox(int capacity) : base(capacity) { }

        public override void Reload()
        {

        }
    }

    public abstract class PoolableAmmo : IAmmo, IPoolable
    {
        private float lifetimeFrames;
        private float lifetimeFramesLeft;

        public abstract void Shoot(Coordinates3D direction, float force);
        
        public bool InUse => lifetimeFramesLeft > 0;

        public void Destroy()
        {
            
        }
    }
}