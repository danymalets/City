using System;
using Sources.Di;

namespace Sources.Services.Fps
{
    public interface IFpsService : IService
    {
        int FpsLastSecond { get; }
        void RunWhenFpsStabilizes(Action action);
    }
}