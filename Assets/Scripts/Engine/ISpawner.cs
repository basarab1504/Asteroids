namespace Asteroids
{
    public interface ISpawner<T> where T : IPositional
    {
        void Spawn();
    }
}