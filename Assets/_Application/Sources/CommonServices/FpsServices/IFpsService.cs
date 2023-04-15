using System;
using _Application.Sources.Utils.Di;

namespace _Application.Sources.CommonServices.FpsServices
{
    public interface IFpsService : IService
    {
        int FpsLastSecond { get; }
        void RunWhenFpsStabilizes(Action action);
    }
}