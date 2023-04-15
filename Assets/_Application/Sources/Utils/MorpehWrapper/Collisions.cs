using System.Collections.Generic;
using _Application.Sources.Utils.CommonUtils.Data;
using Scellecs.Morpeh;

namespace _Application.Sources.Utils.MorpehWrapper
{
    public struct Collisions : IComponent
    {
        public List<CollisionData> List { get; set; }
    }
}