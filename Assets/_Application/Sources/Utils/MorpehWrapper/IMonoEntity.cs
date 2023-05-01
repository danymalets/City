using Scellecs.Morpeh;
using Sources.Services.PoolServices;

namespace Sources.Utils.MorpehWrapper
{
    public interface IMonoEntity : IRespawnable
    {
        void Setup(Entity entity);
        void Cleanup();
    }
}