using Scellecs.Morpeh;
using Sources.Services.PoolServices;

namespace Sources.Utils.MorpehWrapper
{
    public interface IMonoEntity
    {
        void Setup(Entity entity);
        void Cleanup();
    }
}