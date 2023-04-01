using System.Collections.Generic;
using Scellecs.Morpeh;

namespace Sources.App.Game.Ecs.Components.Collections
{
    public struct Collisions : IComponent
    {
        public List<CollisionData> List { get; set; }
    }
}