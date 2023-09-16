using Sources.App.Data.Cars;
using Sources.App.Data.Points;

namespace Sources.App.Core.Ecs.Components.Player.Npc.NpcCar
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