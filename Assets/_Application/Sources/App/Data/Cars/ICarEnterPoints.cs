using System.Collections.Generic;

namespace Sources.Data.Cars
{
    public interface ICarEnterPoints
    {
        IEnumerable<IEnterPoint> EnterPoints { get; }
    }
}