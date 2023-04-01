using System;

namespace Sources.App.Infrastructure.Services.Fps
{
    public interface IFpsService : IService
    {
        int FpsLastSecond { get; }
        void RunWhenFpsStabilizes(Action action);
    }
}