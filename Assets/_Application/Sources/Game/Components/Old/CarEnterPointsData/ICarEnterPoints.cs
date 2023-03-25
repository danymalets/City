using System.Collections.Generic;

namespace Sources.Game.Components.Old.CarEnterPointsData
{
    public interface ICarEnterPoints
    {
        IEnumerable<IEnterPoint> EnterPoints { get; }
    }
}