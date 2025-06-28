using System.Collections.Generic;

namespace Sources.App.Services.AssetsServices.Common.Monos.Cars
{
    public interface ICarEnterPoints
    {
        IEnumerable<IEnterPoint> EnterPoints { get; }
    }
}