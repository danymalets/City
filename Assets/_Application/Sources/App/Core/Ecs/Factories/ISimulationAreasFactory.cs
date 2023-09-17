using Scellecs.Morpeh;
using Sources.App.Data;
using Sources.App.Data.Simulations;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Core.Ecs.Factories
{
    public interface ISimulationAreasFactory : IService
    {
        Entity CreateSimulationArea<TTag>(SimulationBordersData bordersData) 
            where TTag : struct, IComponent;
    }
}