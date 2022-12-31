using Sources.Game.GameObjects.Cars;

namespace Sources.Game.Characters
{
    public class Npc : Character
    {
        private NpcAi _npcAi;

        private void Awake()
        {
            _npcAi = GetComponent<NpcAi>();
        }

        public void Setup(Car car)
        {
            _npcAi.Setup(car);
        }
    }
}