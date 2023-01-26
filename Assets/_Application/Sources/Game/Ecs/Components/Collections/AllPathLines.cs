using System.Collections.Generic;
using Sources.Game.GameObjects.RoadSystem.Pathes;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct AllPathLines : IListOf<PathLine>
    {
        public List<PathLine> List { get; set; }
    }
}