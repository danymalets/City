using Sources.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.Game.Ecs.Components.Npc.NpcCar
{
    public class ChoiceData
    {
        public Point Point { get; }
        public TurnData TurnData { get; }
        public bool IsForceMove { get; set; }

        public ChoiceData(Point point, TurnData turnData)
        {
            Point = point;
            TurnData = turnData;
        }
    }
}