using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.PseudoEditor
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