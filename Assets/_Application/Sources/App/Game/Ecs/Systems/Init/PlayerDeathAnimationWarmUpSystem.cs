using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Factories;
using Sources.App.Game.Ecs.MonoEntities;
using Sources.App.Infrastructure.Services;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Init
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