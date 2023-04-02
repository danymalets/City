using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Data;

namespace Sources.App.Game.Ecs.Components.Collections
{
    public struct AllSpawnPoints : IComponent
    {
        public List<Point> List { get; set; }
    }
}