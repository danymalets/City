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
                ref ListOf<PathLine> pathLines = ref pathesEntity.Get<ListOf<PathLine>>();
                ref ListOf<Point> points = ref pathesEntity.Get<ListOf<Point>>();

                HashSet<Point> pointsSet = new();

                foreach (PathLine pathLine in pathLines)
                {
                    pointsSet.Add(pathLine.Source);
                    pointsSet.Add(pathLine.Target);
                }

                foreach (Point point in pointsSet)
                {
                    points.Add(point);
                }
            }
        }
    }
}