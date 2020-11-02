namespace Asteroids
{
    public class AmmoBox : IAmmoBox
    {
        private int capacity;
        private Pool<Ammo> ammo;

        public int Capacity => capacity;

        public AmmoBox(int capacity)
        {
            this.capacity = capacity;
            ammo = new Pool<Ammo>(Capacity, new Factory<Ammo>());
        }

        public IAmmo GetAmmo()
        {
            return ammo.GetPoolable();
        }
    }
}