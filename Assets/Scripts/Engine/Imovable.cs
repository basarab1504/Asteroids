using System;

namespace Asteroids
{
    public interface IMovable
    {
        // float Speed { get; }
        // float RotationSpeed { get; }
        void Move(Coordinates3D direction);
        void Rotate(float angle);
    }
}