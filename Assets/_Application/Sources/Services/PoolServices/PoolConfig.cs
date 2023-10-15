using UnityEngine;

namespace Sources.Services.PoolServices
{
    public class PoolConfig
    {
        public RespawnableBehaviour Prefab { get; private set; }
        public int Size { get; private set; }
        public Transform ForceParent { get; private set; }
        
        public PoolConfig(RespawnableBehaviour prefab, int size, Transform forceParent = null)
        {
            Prefab = prefab;
            Size = size;
            ForceParent = forceParent;
        }
    }
}