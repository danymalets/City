using Sources.Game.Factories;
using Sources.Game.GameObjects.Cars;

namespace Sources.Game.Controllers
{
    public class NpcWithCarController
    {
        private readonly CarFactory _carFactory;
        private readonly NpcFactory _npcFactory;

        public NpcWithCarController()
        {
            _carFactory = new CarFactory();
            _npcFactory = new NpcFactory();
        }

        public void StartSpawn()
        {
            for (int i = 0; i < 1; i++)
            {
                Car car = _carFactory.Create();
                _npcFactory.Create(car);
            }
        }
    }
}