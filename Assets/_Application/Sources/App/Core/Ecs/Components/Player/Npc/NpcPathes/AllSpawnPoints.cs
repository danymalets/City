using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Data.Points;

namespace Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes
{
    public struct AllSpawnPoints : IComponent
    {
        public List<Point> List { get; set; }
    }
}