using System.Collections.Generic;

namespace Sources.MonoViews
{
    public interface ICarEnterPoints
    {
        IEnumerable<IEnterPoint> EnterPoints { get; }
    }
}