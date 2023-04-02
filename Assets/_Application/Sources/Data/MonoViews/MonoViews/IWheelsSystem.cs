using UnityEngine;

namespace Sources.Data.MonoViews.MonoViews
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