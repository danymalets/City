using System.Collections.Generic;
using _Application.Sources.App.Core.Ecs.Components.NpcPathes;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Pathes;
using _Application.Sources.App.Data.Points;
using _Application.Sources.Utils.CommonUtils.Extensions;
using _Application.Sources.Utils.CommonUtils.Libs;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.PseudoEditor
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
                List<Point> points = pathesEntity.Get<AllPoints>().List;
                List<Point> activePoints = pathesEntity.Get<ActiveSpawnPoints>().List;
                List<Point> horizonPoints = pathesEntity.Get<HorizonSpawnPoints>().List;
                List<PathLine> pathLines = pathesEntity.Get<AllPathLines>().List;

                foreach (PathLine pathLine in pathLines)
                {
                    if (!pathLine.GetAssociatedTurn().IsBlocked())
                        _updateGizmosContext.DrawLine(pathLine.Source.Position, pathLine.Target.Position, Color.blue);
                    else
                        _updateGizmosContext.DrawLine(pathLine.Source.Position, pathLine.Target.Position, DColor.Purple);
                }

                foreach (Point point in points)
                {
                    Color color = point.IsSpawnPoint ? DColor.Purple : Color.red;

                    _updateGizmosContext.DrawCube(
                        point.Position, Quaternion.LookRotation(point.Direction),
                        Vector3.one * 0.15f, color);

                    _updateGizmosContext.DrawCube(
                        point.Position + point.Direction.normalized * 0.1f,
                        Quaternion.LookRotation(point.Direction),
                        Vector3.one * 0.1f, color);

                    if (activePoints.Contains(point))
                    {
                        _updateGizmosContext.DrawSphere(
                            point.Position + point.Direction.normalized * 0.1f, 0.2f,
                            Color.red.WithAlpha(0.5f));
                    }
                }

                // foreach (Point point in activePoints)
                // {
                //     _updateGizmosContext.DrawSphere(
                //         point.Position + point.Direction.normalized * 0.1f, 2f,
                //         Color.red.WithAlpha(1f));
                // }
                // foreach (Point point in horizonPoints)
                // {
                //     _updateGizmosContext.DrawSphere(
                //         point.Position + point.Direction.normalized * 0.1f, 2f,
                //         Color.yellow.WithAlpha(1f));
                // }
            }
        }
    }
}