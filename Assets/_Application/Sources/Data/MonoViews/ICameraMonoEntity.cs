using Sources.Utils.DMorpeh;
using Sources.Utils.DMorpeh.DefaultComponents.Views;

namespace Sources.Data.MonoViews
{
    public interface ICameraMonoEntity : IMonoEntity
    {
        ITransform Transform { get; }
        ICamera Camera { get; }
    }
}