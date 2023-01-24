using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.PseudoEditor
{
    public class PathesGizmosSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PathesTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity pathesEntity in _filter)
            {
                ref ListOf<PathLine> pathLines = ref pathesEntity.Get<ListOf<PathLine>>();
                ref ListOf<Point> points = ref pathesEntity.Get<ListOf<Point>>();

                foreach (PathLine pathLine in pathLines)
                {
                    _updateGizmosContext.DrawLine(pathLine.Source.Position, pathLine.Target.Position, Color.blue);
                }
                
                foreach (Point point in points.Where(p => p.IsSpawnPoint))
                {
                    _updateGizmosContext.DrawCube(
                        point.Position, Quaternion.LookRotation(point.Direction), 
                        Vector3.one * 0.4f, Color.red);
                    
                    _updateGizmosContext.DrawCube(
                        point.Position + point.Direction.normalized * 0.2f, 
                        Quaternion.LookRotation(point.Direction),
                        Vector3.one * 0.25f, Color.red);
                }
            }
        }
    }
}