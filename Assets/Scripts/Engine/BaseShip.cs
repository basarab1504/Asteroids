using System;
using System.Collections.Generic;

namespace Asteroids
{
    public class BaseShip : IShip
    {
        private Coordinates3D position;
        private List<BaseGun> guns;

        public float Speed { get; }
        public IEnumerable<IGun> Guns => guns;

        public void Move(Coordinates3D direction)
        {
            position = position + direction * Speed;
        }
        public void Rotate(float angle) { }
        public void Shoot(Coordinates3D direction) { }
        public void Destroy() { }
    }
}