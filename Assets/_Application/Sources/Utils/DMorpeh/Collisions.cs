using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.Data;

namespace Sources.Utils.DMorpeh
{
    public struct Collisions : IComponent
    {
        public List<CollisionData> List { get; set; }
    }
}