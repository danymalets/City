using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Cars.CarsData
{
    public interface IWheelsSystem
    {
        AxleInfo[] AxleInfo { get; }
        Vector3 RootOffset { get; }
        Vector3 RootPosition { get; }
        void EnableSystem();
        void DisableSystem();
        void SetSystemEnabled(bool enabled);
    }
}