using Scellecs.Morpeh;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class EntityMonoExtensions
    {
        public static IMonoEntity GetMonoEntity(this Entity entity) =>
            entity.GetRef<IMonoEntity>();
        
        public static void DespawnMono(this Entity entity)
        {
            entity.GetMonoEntity().Cleanup();
        }
    }
}