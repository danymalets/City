using System;
using Sources.Data.Live;

namespace Sources.Infrastructure.Services.Fps
{
    public interface IFpsService : IService
    {
        int FpsLastSecond { get; }
        void RunWhenFpsStabilizes(Action action);
    }
}