using System;
using Sources.Utils.Di;

namespace Sources.CommonServices.FpsServices
{
    public interface IFpsService : IService
    {
        int FpsLastSecond { get; }
        void RunWhenFpsStabilizes(Action action);
    }
}