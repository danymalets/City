using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Camera;
using Sources.App.Core.Ecs.Components.SimulationAreas;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data;
using Sources.App.Data.MonoEntities;
using Sources.App.Data.Simulations;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;

namespace Sources.App.Core.Ecs.Factories
{
    public class SimulationAreasFactory : Factory, ISimulationAreasFactory
    {
        public Entity CreateSimulationArea<TTag>(SimulationBordersData bordersData) 
            where TTag : struct, IComponent
        {
            return _world.CreateEntity()
                .Add<SimulationAreaTag>()
                .Add<TTag>()
                .Set(new SimulationBorders(){BordersData = bordersData})
                .Add<SimulationArea>();
        }
    }
}