using Sources.Game.Characters;
using Sources.Game.GameObjects.Cars;

namespace Sources.Game.Factories
{
    public class NpcFactory: Factory
    {

        public NpcFactory()
        {
        }
            
        public Npc Create(Car car)
        {
            Npc npc = _poolInstantiator.Instantiate(_assets.NpcPrefab);
            npc.Setup(car);
            return npc;
        }
    }
}