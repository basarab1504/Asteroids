namespace Asteroids
{
    public class PoolableAmmo : IAmmo, IPoolable
    {
        public bool InUse => Time.time < bornTick + lifetime;

        public void Shoot(Coordinates3D direction, float force)
        {

        }

        public void Destroy()
        {
            
        }
    }
}