using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.NpcPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Init
{
    public class PathesPointsFindSystem : DInitializer
    {
        private Filter _filter;

        protected override void OnInitFilters()
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