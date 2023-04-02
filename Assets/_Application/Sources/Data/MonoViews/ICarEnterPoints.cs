using System.Collections.Generic;

namespace Sources.Data.MonoViews
{
    public interface ICarEnterPoints
    {
        IEnumerable<IEnterPoint> EnterPoints { get; }
    }
}