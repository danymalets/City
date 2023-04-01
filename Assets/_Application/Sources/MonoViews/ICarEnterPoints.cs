using System.Collections.Generic;

namespace _Application.Sources.MonoViews
{
    public interface ICarEnterPoints
    {
        IEnumerable<IEnterPoint> EnterPoints { get; }
    }
}