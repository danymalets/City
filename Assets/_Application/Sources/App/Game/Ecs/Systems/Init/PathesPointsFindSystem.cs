using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Collections;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.GameObjects.RoadSystem.Pathes;
using Sources.App.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.App.Game.Ecs.Systems.Init
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