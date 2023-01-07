using System.Linq;
using System.Numerics;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Factories.Npc;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Utilities.Extensions;

namespace Sources.Game.Ecs.Systems.Init
{
    public class NpcWithCarsInitSystem : DInitializer
    {
        private readonly ICarFactory _carFactory;
        private readonly INpcFactory _npcFactory;
        private IPathSystem _pathSystem;

        public NpcWithCarsInitSystem()
        {
            _carFactory = DiContainer.Resolve<ICarFactory>();
            _npcFactory = DiContainer.Resolve<INpcFactory>();
        }

        protected override void OnInitFilters()
        {
        }

        protected override void OnInitialize()
        {
            _pathSystem = _world.GetMonoSingleton<IPathSystem>();

            for (int i = 0; i < 12; i++)
            {
                IConnectingPoint point = _pathSystem.Points
                    .Where(p => p.IsRoot).ToArray().GetRandom();
                
                Entity car = _carFactory.CreateCar(point.Position, point.Rotation);
                
                // надо рут поинт в этой точке спавнить

                _npcFactory.Create(car);
            }
            
        }
    }
}