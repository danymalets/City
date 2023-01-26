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

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PathesTag>();
        }

        protected override void OnInitialize()
        {
            foreach (Entity pathesEntity in _filter)
            {
                List<Point> points = pathesEntity.GetList<AllSpawnPoints, Point>();
                List<PathLine> pathLines = pathesEntity.GetList<AllPathLines, PathLine>();

                HashSet<Point> pointsSet = new();

                foreach (PathLine pathLine in pathLines)
                {
                    pointsSet.Add(pathLine.Source);
                    pointsSet.Add(pathLine.Target);
                }

                foreach (Point point in pointsSet)
                {
                    if (point.IsSpawnPoint)
                        points.Add(point);
                }
            }
        }
    }
}