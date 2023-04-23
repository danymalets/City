using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Data.Points;

namespace Sources.App.Core.Ecs.Components.NpcPathes
{
    public struct AllSpawnPointsGrid : IComponent
    {
        public Dictionary<(int x, int y), List<Point>> Grid;
    }
}