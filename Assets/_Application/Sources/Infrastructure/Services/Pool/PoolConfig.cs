namespace Sources.Infrastructure.Services.Pool
{
    public class PoolConfig
    {
        public RespawnableBehaviour Prefab { get; private set; }
        public int Size { get; private set; }

        public PoolConfig(RespawnableBehaviour prefab, int size)
        {
            Prefab = prefab;
            Size = size;
        }
    }
}