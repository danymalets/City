using Sources.Game.GameObjects.Cars;
using UnityEngine;

namespace Sources.Game.Components.Views
{
    public interface IWheelsSystem
    {
        AxleInfo[] AxleInfo { get; }
        Vector3 RootOffset { get; }
        Vector3 RootPosition { get; }
    }
}