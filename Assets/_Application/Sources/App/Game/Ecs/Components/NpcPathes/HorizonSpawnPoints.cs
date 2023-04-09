using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Data.Points;

namespace Sources.App.Game.Ecs.Components.NpcPathes
{
    public struct HorizonSpawnPoints : IComponent
    {
        public List<Point> List { get; set; }
    }
}