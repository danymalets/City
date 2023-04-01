using System.Collections.Generic;

namespace Sources.App.Game.Components.Old.CarEnterPointsData
{
    public interface ICarEnterPoints
    {
        IEnumerable<IEnterPoint> EnterPoints { get; }
    }
}