using Sources.Data.Live;

namespace Sources.Infrastructure.Services.Fps
{
    public interface IFpsService : IService
    {
        LiveInt FpsLastSecond { get; }
    }
}