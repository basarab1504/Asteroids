using System;
using System.Collections.Generic;

namespace Asteroids
{
    public struct Coordinates3D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Coordinates3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Coordinates3D operator +(Coordinates3D a, Coordinates3D b)
        {
            return new Coordinates3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Coordinates3D operator -(Coordinates3D a, Coordinates3D b)
        {
            return new Coordinates3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Coordinates3D operator *(Coordinates3D a, float d)
        {
            return new Coordinates3D(a.X * d, a.Y * d, a.Z * d);
        }
        public static Coordinates3D operator *(float d, Coordinates3D a)
        {
            return new Coordinates3D(a.X * d, a.Y * d, a.Z * d);
        }
        public static Coordinates3D operator /(Coordinates3D a, float d)
        {
            return new Coordinates3D(a.X / d, a.Y / d, a.Z / d);
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinates3D d &&
                   X == d.X &&
                   Y == d.Y &&
                   Z == d.Z;
        }

        public override int GetHashCode()
        {
            int hashCode = -307843816;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }
    }
}

