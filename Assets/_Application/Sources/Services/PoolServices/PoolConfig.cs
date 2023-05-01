namespace Sources.Services.PoolServices
{
    public class PoolConfig
    {
        public IRespawnable Prefab { get; private set; }
        public int Size { get; private set; }

        public PoolConfig(IRespawnable prefab, int size)
        {
            Prefab = prefab;
            Size = size;
        }
    }
}