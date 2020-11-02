using System.Collections.Generic;

namespace Asteroids
{
    public class Pool<T> : IPool<T> where T : IPoolable
    {
        private List<T> pool;

        public IEnumerable<T> Poolables
        {
            get
            {
                foreach (var item in pool)
                {
                    if (item.InUse)
                        yield return item;
                }
            }
        }

        public Pool(int size, IFactory<T> factory)
        {
            pool = new List<T>(size);
            for (int i = 0; i < size; i++)
                factory.Create();
        }

        public T GetPoolable()
        {
            foreach (var p in pool)
                if (!p.InUse)
                    return p;
            return default(T);
        }
    }
}