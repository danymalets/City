using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.Game.Ecs.Systems.Init
{
    public class PathesPointsFindSystem : DInitializer
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PathesTag>();
        }

        protected override void OnInitialize()
        {
            foreach (Entity pathesEntity in _filter)
            {
                List<Point> allPoints = pathesEntity.Get<AllPoints>().List;
                List<Point> spawnPoints = pathesEntity.Get<AllSpawnPoints>().List;
                List<PathLine> pathLines = pathesEntity.Get<AllPathLines>().List;

                HashSet<Point> pointsSet = new();

                foreach (PathLine pathLine in pathLines)
                {
                    pointsSet.Add(pathLine.Source);
                    pointsSet.Add(pathLine.Target);
                }

                foreach (Point point in pointsSet)
                {
                    allPoints.Add(point);
                    
                    if (point.IsSpawnPoint)
                        spawnPoints.Add(point);
                }
            }
        }
    }
}