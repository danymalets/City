using Leopotam.Ecs;

namespace Sources.Game.Ecs.Utils
{
    public static class EcsExtensions
    {
        public static void Add<T>(this EcsEntity entity) where T : struct =>
            entity.Get<T>();
        
        public static void Set<T>(this EcsEntity entity, T item) where T : struct =>
            entity.Replace(item);

        public static int GetEntitiesCount(this EcsFilter filter)
        {
            int count = 0;
            foreach (int i in filter)
            {
                count++;
            }
            return count;
        }
    }
}