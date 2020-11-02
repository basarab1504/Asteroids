using System;

namespace Asteroids
{
    public class Spawner<T> : ISpawner<T> where T : IPositional
    {
        private IFactory<T> factory;
        public Coordinates3D SpawnAreaSize { get; set; }

        public Spawner(IFactory<T> factory)
        {
            this.factory = factory;
        }

        public void Spawn()
        {
            var spawned = factory.Create();
            spawned.Position = GetPosition();
        }

        private Coordinates3D GetPosition()
        {
            float x;
            float y;

            var areaSizeX = SpawnAreaSize.X * 0.5f;
            var areaSizeY = SpawnAreaSize.Y * 0.5f;

            var rnd = new Random();

            bool XoY = rnd.Next(0, 100) > 50 ? true : false;

            if (XoY)
            {
                x = rnd.Next(0, 100) > 50 ? -areaSizeX : areaSizeX;
                y = (float)rnd.NextDouble() * (areaSizeY - (-areaSizeY)) + (-areaSizeY);
            }
            else
            {
                y = rnd.Next(0, 100) > 50 ? -areaSizeY : areaSizeY;
                x = (float)rnd.NextDouble() * (areaSizeX - (-areaSizeX)) + (-areaSizeX);
            }

            return new Coordinates3D(x, y, 0);
        }
    }
}