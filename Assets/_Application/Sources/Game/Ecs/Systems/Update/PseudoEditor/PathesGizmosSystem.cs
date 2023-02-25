using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.PseudoEditor
{
    public class PathesGizmosSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PathesTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity pathesEntity in _filter)
            {
                List<Point> points = pathesEntity.Get<AllSpawnPoints>().List;
                List<PathLine> pathLines = pathesEntity.Get<AllPathLines>().List;

                foreach (PathLine pathLine in pathLines)
                {
                    if (!pathLine.GetAssociatedTurn().IsBlocked())
                        _updateGizmosContext.DrawLine(pathLine.Source.Position, pathLine.Target.Position, Color.blue);
                    else
                        _updateGizmosContext.DrawLine(pathLine.Source.Position, pathLine.Target.Position, DColor.Purple);
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