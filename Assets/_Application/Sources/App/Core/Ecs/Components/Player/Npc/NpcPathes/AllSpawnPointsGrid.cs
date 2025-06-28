using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Data;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points;

namespace Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes
{
    public struct AllSpawnPointsGrid : IComponent
    {
        public Dictionary<(int x, int y), List<Point>> Grid;
    }
}