using Sources.DMorpeh.DefaultComponents;
using UnityEngine;

namespace _Application.Sources.MonoViews.MonoViews
{
    public interface IWheelsSystem
    {
        AxleInfo[] AxleInfo { get; }
        Vector3 RootOffset { get; }
        Vector3 RootPosition { get; }
    }
}