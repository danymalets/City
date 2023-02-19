using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct ActiveSpawnPoints : IComponent
    {
        public List<Point> List { get; set; }
    }
}