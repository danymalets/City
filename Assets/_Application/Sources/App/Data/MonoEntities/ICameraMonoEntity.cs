using _Application.Sources.Utils.MorpehWrapper;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;

namespace _Application.Sources.App.Data.MonoEntities
{
    public interface ICameraMonoEntity : IMonoEntity
    {
        ITransform Transform { get; }
        ICamera Camera { get; }
    }
}