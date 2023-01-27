using System.Collections.Generic;
using Sources.Game.Ecs.Utils;

namespace Sources.Game.Ecs.Components.Views.CarEnterPointsData
{
    public interface ICarEnterPoints : IMonoComponent
    {
        IEnumerable<IEnterPoint> EnterPoints { get; }
    }
}