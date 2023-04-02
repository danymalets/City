using Scellecs.Morpeh;
using Sources.Services.Pool;

namespace Sources.Utils.DMorpeh
{
    public interface IMonoEntity : IRespawnable
    {
        void Setup(Entity entity);
        void Cleanup();
    }
}