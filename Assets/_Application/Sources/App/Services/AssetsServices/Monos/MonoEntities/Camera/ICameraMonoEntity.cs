using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;

namespace Sources.App.Services.AssetsServices.Monos.MonoEntities.Camera
{
    public interface ICameraMonoEntity : IMonoEntity
    {
        ITransform Transform { get; }
        ICamera Camera { get; }
    }
}