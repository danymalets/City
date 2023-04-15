using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.CommonUtils.Data;

namespace Sources.Utils.MorpehWrapper
{
    public struct Collisions : IComponent
    {
        public List<CollisionData> List { get; set; }
    }
}