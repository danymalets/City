

using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Pathes;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points;

namespace Sources.App.Core.Ecs.Data
{
    public class TurnChoice
    {
        public Point Point { get; }
        public TurnData TurnData { get; }
        public bool IsForceMove { get; set; }

        public TurnChoice(Point point, TurnData turnData)
        {
            Point = point;
            TurnData = turnData;
        }
    }
}