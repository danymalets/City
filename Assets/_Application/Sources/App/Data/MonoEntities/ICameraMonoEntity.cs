using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;

namespace Sources.App.Data.MonoEntities
{
    public interface ICameraMonoEntity : IMonoEntity
    {
        ITransform Transform { get; }
        ICamera Camera { get; }
    }
}