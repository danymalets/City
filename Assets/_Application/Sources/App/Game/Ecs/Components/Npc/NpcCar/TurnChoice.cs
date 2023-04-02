using Sources.Data;

namespace Sources.App.Game.Ecs.Components.Npc.NpcCar
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