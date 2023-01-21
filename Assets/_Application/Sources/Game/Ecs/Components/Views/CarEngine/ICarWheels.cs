using Sources.Game.Ecs.Utils;
using Sources.Game.GameObjects.Cars;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarEngine
{
    public interface ICarWheels : IMonoComponent
    {
        Vector3 RootPosition { get; }
        Vector3 RootOffset { get; }
        
        AxleInfo[] AxleInfo { get; }
    }
}