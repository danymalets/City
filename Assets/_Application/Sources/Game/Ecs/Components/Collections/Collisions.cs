using System.Collections.Generic;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct Collisions : IListOf<CollisionData>
    {
        public List<CollisionData> List { get; set; }
    }
}