using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Components.Collections
{
    public class CollisionData
    {
        public Entity Entity { get; }
        public float SqrImpulse { get; }

        public CollisionData(Entity entity, float sqrImpulse)
        {
            Entity = entity;
            SqrImpulse = sqrImpulse;
        }
    }
}