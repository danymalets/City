using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct Collisions : IComponent
    {
        public List<CollisionData> List { get; set; }
    }
}