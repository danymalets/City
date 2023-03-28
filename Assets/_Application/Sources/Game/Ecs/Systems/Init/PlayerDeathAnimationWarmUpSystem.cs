using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Init
{
    public class PlayerDeathAnimationWarmUpSystem : DInitializer
    {
        private readonly IPlayersFactory _playersFactory;

        public PlayerDeathAnimationWarmUpSystem()
        {
            _playersFactory = DiContainer.Resolve<IPlayersFactory>();
        }

        protected override void OnInitialize()
        {
            PlayerMonoEntity playerPrefab = _playersFactory.GetRandomPlayerPrefab();
            Entity npcEntity = _playersFactory.CreateNpc(playerPrefab, new Vector3(100, 0, 100), Quaternion.identity);

            npcEntity.Add<AlwaysActive>();
            npcEntity.Add<DeadRequest>();
            npcEntity.AddWithDelay<DespawnRequest>(3f);
        }
    }
}