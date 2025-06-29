using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Data;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Init.Pathes
{
    public class CrosswalksBlocksGenerationSystem : CustomInitializer
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PathesTag>().Build();
        }

        protected override void OnInitialize()
        {
            foreach (Entity pathesEntity in _filter)
            {
                List<PathLine> pathLines = pathesEntity.Get<AllPathLines>().List;
                List<ICrossroads> crossroads = pathesEntity.Get<AllCrossroads>().List;

                foreach (ICrossroads crossroad in crossroads)
                {
                    Generate(pathLines, crossroad);
                }
            }
        }

        private void Generate(List<PathLine> pathLines, ICrossroads crossroad)
        {
            GenerateCrosswalksBlocks(crossroad, crossroad.Forward, crossroad.ForwardRelated);
            GenerateCrosswalksBlocks(crossroad, crossroad.Left, crossroad.LeftRelated);
            GenerateCrosswalksBlocks(crossroad, crossroad.Back, crossroad.BackRelated);
            GenerateCrosswalksBlocks(crossroad, crossroad.Right, crossroad.RightRelated);
        }
        
        private void GenerateCrosswalksBlocks(ICrossroads crossroads, IRoad road, IRoad crosswalk)
        {
            if (road == null || crosswalk == null)
                return;
            
            CrossroadsSideData roadSideData = road.GetSideData(crossroads.Position);
            IRoadLane[] crosswalkLanes = crosswalk.GetLanesByDistanceTo(crossroads.Position);

            PathPoint roadSource = roadSideData.Sources.First();
            PathPoint roadTarget = roadSideData.Targets.First();
            
            IRoadLane firstCrosswalkLane = crosswalkLanes[0];
            IRoadLane secondCrosswalkLane = crosswalkLanes[1];

            PathPoint firstCrosswalkLaneSource = firstCrosswalkLane.Source.RelatedPoint;
            PathPoint firstCrosswalkLaneTarget = firstCrosswalkLane.Target.RelatedPoint;
            PathPoint secondCrosswalkLaneSource = secondCrosswalkLane.Source.RelatedPoint;
            PathPoint secondCrosswalkLaneTarget = secondCrosswalkLane.Target.RelatedPoint;

            firstCrosswalkLaneSource.GetSimpleTurn().TargetPoint = firstCrosswalkLaneTarget;
            firstCrosswalkLaneSource.GetSimpleTurn().BlockableTurns.Add(roadSource.GetSimpleTurn());
            firstCrosswalkLaneSource.GetSimpleTurn().BlockableTurns.Add(roadTarget.GetPreviousTurn());  
            
            secondCrosswalkLaneSource.GetSimpleTurn().TargetPoint = secondCrosswalkLaneTarget;
            secondCrosswalkLaneSource.GetSimpleTurn().BlockableTurns.Add(roadSource.GetSimpleTurn());
            secondCrosswalkLaneSource.GetSimpleTurn().BlockableTurns.Add(roadTarget.GetPreviousTurn());
            
            roadSource.GetSimpleTurn().TargetPoint = roadSource.GetSimpleTurn().FirstPathLine.Target;
            roadSource.GetSimpleTurn().BlockableTurns.Add(firstCrosswalkLaneSource.GetSimpleTurn());
            roadSource.GetSimpleTurn().BlockableTurns.Add(secondCrosswalkLaneSource.GetSimpleTurn());
            
            roadTarget.GetPreviousTurn().TargetPoint = roadTarget;
            roadTarget.Sources.First().Source.GetSimpleTurn().BlockableTurns.Add(firstCrosswalkLaneSource.GetSimpleTurn());
            roadTarget.Sources.First().Source.GetSimpleTurn().BlockableTurns.Add(secondCrosswalkLaneSource.GetSimpleTurn());
        }
    }
}