using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Init
{
    public class PlayerDeathAnimationWarmUpSystem : DInitializer
    {
        protected override void OnInitialize()
        {
            PlayerMonoEntity playerPrefab = _factory.GetRandomPlayerPrefab();
            Entity npcEntity = _factory.CreateNpc(playerPrefab, new Vector3(100, 0, 100), Quaternion.identity);

            npcEntity.Add<AlwaysActive>();
            npcEntity.Add<DeadRequest>();
            npcEntity.AddWithDelay<DespawnRequest>(3f);
        }
    }
}