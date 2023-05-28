using System;
using Sources.Utils.Di;

namespace Sources.Services.FpsServices
{
    public interface IFpsService : IService
    {
        float FpsLastSecond { get; }
        void RunWhenFpsStabilizes(Action action);
    }
}