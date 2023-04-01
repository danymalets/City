using Sources.App.Game.GameObjects.Cars;
using UnityEngine;

namespace Sources.App.Game.Components.Monos
{
    public interface IWheelsSystem
    {
        AxleInfo[] AxleInfo { get; }
        Vector3 RootOffset { get; }
        Vector3 RootPosition { get; }
    }
}