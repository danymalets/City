using System.Collections.Generic;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct ActiveTurns : IListOf<TurnData>
    {
        public List<TurnData> List { get; set; }
    }
}