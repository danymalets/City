using Scellecs.Morpeh;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class EntityMonoExtensions
    {
        public static IMonoEntity GetMonoEntity(this Entity entity) =>
            entity.Get<MonoEntityAccess>().MonoEntity;
        
        public static void DespawnMono(this Entity entity)
        {
            entity.GetMonoEntity().Cleanup();
        }
    }
}