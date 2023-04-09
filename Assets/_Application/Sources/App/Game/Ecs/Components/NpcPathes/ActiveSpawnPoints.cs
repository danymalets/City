using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Data.Points;

namespace Sources.App.Game.Ecs.Components.NpcPathes
{
    public struct ActiveSpawnPoints : IComponent
    {
        public List<Point> List { get; set; }
    }
}