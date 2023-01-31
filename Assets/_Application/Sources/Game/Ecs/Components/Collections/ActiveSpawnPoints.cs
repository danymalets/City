using System.Collections.Generic;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct ActiveSpawnPoints : IListOf<Point>
    {
        public List<Point> List { get; set; }
    }
}