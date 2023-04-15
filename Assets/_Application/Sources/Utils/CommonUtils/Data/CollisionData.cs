using Scellecs.Morpeh;

namespace Sources.Utils.CommonUtils.Data
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