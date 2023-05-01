using System;
using Sources.Utils.Di;

namespace Sources.Services.FpsServices
{
    public interface IFpsService : IService
    {
        int FpsLastSecond { get; }
        void RunWhenFpsStabilizes(Action action);
    }
}