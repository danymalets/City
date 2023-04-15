using Scellecs.Morpeh;
using Sources.CommonServices.PoolServices;

namespace Sources.Utils.MorpehWrapper
{
    public interface IMonoEntity : IRespawnable
    {
        void Setup(Entity entity);
        void Cleanup();
    }
}