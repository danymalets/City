using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class PlayerFallCheckSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly PlayersBalance _playersBalance;

        public PlayerFallCheckSystem()
        {
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag, Collisions>().Without<Dead>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                List<CollisionData> collisions = playerEntity.Get<Collisions>().List;
                foreach (CollisionData collisionData in collisions)
                {
                    if (collisionData.SqrImpulse > DMath.Sqr(_playersBalance.MinImpulseForFall))
                    {
                        playerEntity.AddIfNotHas<DeadRequest>();
                    }
                }
            }
        }
    }
}