using System.Collections.Generic;

namespace _Application.Sources.App.Data.Cars
{
    public interface ICarEnterPoints
    {
        IEnumerable<IEnterPoint> EnterPoints { get; }
    }
}