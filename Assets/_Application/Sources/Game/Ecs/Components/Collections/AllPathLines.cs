using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.GameObjects.RoadSystem.Pathes;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct AllPathLines : IComponent
    {
        public List<PathLine> List { get; set; }
    }
}