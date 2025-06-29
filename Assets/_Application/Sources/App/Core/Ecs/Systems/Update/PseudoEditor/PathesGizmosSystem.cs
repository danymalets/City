using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Data;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Utils;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.PseudoEditor
{
    public class PathesGizmosSystem : CustomUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PathesTag>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity pathesEntity in _filter)
            {
                List<PathPoint> points = pathesEntity.Get<AllPoints>().List;
                List<PathPoint> activePoints = pathesEntity.Get<ActiveSpawnPoints>().List;
                List<PathPoint> horizonPoints = pathesEntity.Get<HorizonSpawnPoints>().List;
                List<PathLine> pathLines = pathesEntity.Get<AllPathLines>().List;

                foreach (PathLine pathLine in pathLines)
                {
                    if (!pathLine.GetAssociatedTurn().IsBlocked())
                        _updateGizmosContext.DrawLine(pathLine.Source.Position, pathLine.Target.Position, Color.blue);
                    else
                        _updateGizmosContext.DrawLine(pathLine.Source.Position, pathLine.Target.Position, ColorUtils.Purple);
                }

                foreach (PathPoint point in points)
                {
                    Color color = point.IsSpawnPoint ? ColorUtils.Purple : Color.red;

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

                // foreach (PathPoint point in activePoints)
                // {
                //     _updateGizmosContext.DrawSphere(
                //         point.Position + point.Direction.normalized * 0.1f, 2f,
                //         Color.red.WithAlpha(1f));
                // }
                // foreach (PathPoint point in horizonPoints)
                // {
                //     _updateGizmosContext.DrawSphere(
                //         point.Position + point.Direction.normalized * 0.1f, 2f,
                //         Color.yellow.WithAlpha(1f));
                // }
            }
        }
    }
}