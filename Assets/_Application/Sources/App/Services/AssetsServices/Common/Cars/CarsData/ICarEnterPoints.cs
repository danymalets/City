using System.Collections.Generic;

namespace Sources.App.Services.AssetsServices.Common.Cars.CarsData
{
    public interface ICarEnterPoints
    {
        IEnumerable<IEnterPoint> EnterPoints { get; }
    }
}