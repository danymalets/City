using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Common;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.App.Services.AssetsServices.Monos.MonoEntities.Player;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Init
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
            IPlayerMonoEntity playerPrefab = _playersFactory.GetRandomPlayerPrefab();
            Entity npcEntity = _playersFactory.CreateNpc(playerPrefab, new Vector3(100, 0, 100), Quaternion.identity);

            npcEntity.Add<AlwaysActive>();
            npcEntity.Add<DeadRequest>();
            npcEntity.AddWithFixedDelay<DespawnRequest>(3f);
        }
    }
}