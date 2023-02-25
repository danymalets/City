using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Init
{
    public class CrosswalksBlocksGenerationSystem : DInitializer
    {
        private Filter _filter;
        private SimulationBalance _simulationBalance;

        protected override void OnConstruct()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
            _filter = _world.Filter<PathesTag>();
        }

        protected override void OnInitialize()
        {
            foreach (Entity pathesEntity in _filter)
            {
                List<PathLine> pathLines = pathesEntity.Get<AllPathLines>().List;
                List<Crossroads> crossroads = pathesEntity.Get<AllCrossroads>().List;

                foreach (Crossroads crossroad in crossroads)
                {
                    Generate(pathLines, crossroad);
                }
            }
        }

        private void Generate(List<PathLine> pathLines, Crossroads crossroad)
        {
            GenerateCrosswalksBlocks(crossroad, crossroad.Forward, crossroad.ForwardRelated);
            GenerateCrosswalksBlocks(crossroad, crossroad.Left, crossroad.LeftRelated);
            GenerateCrosswalksBlocks(crossroad, crossroad.Back, crossroad.BackRelated);
            GenerateCrosswalksBlocks(crossroad, crossroad.Right, crossroad.RightRelated);
        }
        
        private void GenerateCrosswalksBlocks(Crossroads crossroads, Road road, Road crosswalk)
        {
            if (road == null || crosswalk == null)
                return;
            
            CrossroadsSideData roadSideData = road.GetSideData(crossroads.transform.position);
            RoadLane[] crosswalkLanes = crosswalk.GetLanesByDistanceTo(crossroads.transform.position);

            Point roadSource = roadSideData.Sources.First();
            Point roadTarget = roadSideData.Targets.First();
            
            RoadLane firstCrosswalkLane = crosswalkLanes[0];
            RoadLane secondCrosswalkLane = crosswalkLanes[1];

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