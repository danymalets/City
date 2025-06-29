using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;

namespace Sources.App.Core.Ecs.Data
{
    public class TurnChoice
    {
        public PathPoint Point { get; }
        public TurnData TurnData { get; }
        public bool IsForceMove { get; set; }

        public TurnChoice(PathPoint point, TurnData turnData)
        {
            Point = point;
            TurnData = turnData;
        }
    }
}