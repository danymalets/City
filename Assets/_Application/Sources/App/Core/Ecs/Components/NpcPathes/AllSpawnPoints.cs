using System.Collections.Generic;
using _Application.Sources.App.Data.Points;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Components.NpcPathes
{
    public struct AllSpawnPoints : IComponent
    {
        public List<Point> List { get; set; }
    }
}