using _Application.Sources.CommonServices.PoolServices;
using Scellecs.Morpeh;

namespace _Application.Sources.Utils.MorpehWrapper
{
    public interface IMonoEntity : IRespawnable
    {
        void Setup(Entity entity);
        void Cleanup();
    }
}