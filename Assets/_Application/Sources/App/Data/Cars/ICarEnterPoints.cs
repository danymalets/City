using System.Collections.Generic;

namespace Sources.App.Data.Cars
{
    public interface ICarEnterPoints
    {
        IEnumerable<IEnterPoint> EnterPoints { get; }
    }
}