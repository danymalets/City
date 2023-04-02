using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Collections;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Factories;
using Sources.Data;
using Sources.Data.MonoViews;
using Sources.Monos;
using Sources.Services.AssetsManager;
using Sources.Services.BalanceManager;
using Sources.Services.Di;
using Sources.Services.Physics;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Extensions;

namespace Sources.App.Game.Ecs.Systems.Init
{
    public class NpcInitSystem : DInitializer
    {
        private readonly IPhysicsService _physics;
        private readonly Assets _assets;
        private readonly IPathSystem _pathSystem;
        private readonly SimulationBalance _simulationBalance;
        private Filter _npcPathesFilter;
        private readonly PlayersBalance _playersBalance;
        private readonly IPlayersFactory _playersFactory;

        public NpcInitSystem()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
            _assets = DiContainer.Resolve<Assets>();
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
            _pathSystem = DiContainer.Resolve<ILevelContext>().NpcPathSystem;
            _playersFactory = DiContainer.Resolve<IPlayersFactory>();
        }

        protected override void OnConstruct()
        {
            _npcPathesFilter = _world.Filter<NpcsPathesTag>();
        }

        protected override void OnInitialize()
        {
            Entity npcPathes = _npcPathesFilter.GetSingleton();

            Point[] points = npcPathes.Get<ActiveSpawnPoints>().List
                .Concat(npcPathes.Get<HorizonSpawnPoints>().List).ToArray();

            points.RandomShuffle();

            int count = 0;
            int reqCount = points.Length * _simulationBalance.NpcCountPer1000SpawnPoints / 1000;

            foreach (Point point in points)
            {
                if (count == reqCount)
                    break;
                
                if (_playersFactory.TryCreateRandomNpc(point, out Entity createdEntity))
                {
                    _physics.SyncTransforms();

                    count++;
                }
            }
        }
    }
}