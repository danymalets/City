using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.CommonUtils.Data;
using Sources.Utils.MorpehWrapper.MorpehUtils.Components;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class EntityCollisionsExtensions
    {
        public static Entity TrackCollisions(this Entity entity) =>
            entity.Set(new Collisions { List = new List<CollisionData>() });
    }
}