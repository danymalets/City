using System.Collections.Generic;
using System.Linq;
using _Application.Sources.App.Core.Ecs.Components.NpcPathes;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Pathes;
using _Application.Sources.App.Data.Points;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Systems.Init
{
    public class CrosswalksBlocksGenerationSystem : DInitializer
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

            Point roadSource = roadSideData.Sources.First();
            Point roadTarget = roadSideData.Targets.First();
            
            IRoadLane firstCrosswalkLane = crosswalkLanes[0];
            IRoadLane secondCrosswalkLane = crosswalkLanes[1];

            Point firstCrosswalkLaneSource = firstCrosswalkLane.Source.RelatedPoint;
            Point firstCrosswalkLaneTarget = firstCrosswalkLane.Target.RelatedPoint;
            Point secondCrosswalkLaneSource = secondCrosswalkLane.Source.RelatedPoint;
            Point secondCrosswalkLaneTarget = secondCrosswalkLane.Target.RelatedPoint;

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