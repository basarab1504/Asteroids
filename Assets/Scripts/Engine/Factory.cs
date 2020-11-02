using System;

namespace Asteroids
{
    public class Factory<T> : IFactory<T>
    {
        public T Create()
        {
            return Activator.CreateInstance<T>();
        }
    }
}