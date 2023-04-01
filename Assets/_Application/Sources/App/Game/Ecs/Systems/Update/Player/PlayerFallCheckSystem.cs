using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Collections;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Services.BalanceManager;
using Sources.Services.Di;
using Sources.Utils.Data;
using Sources.Utils.DMorpeh;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Libs;

namespace Sources.App.Game.Ecs.Systems.Update.Player
{
    public class PlayerFallCheckSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly PlayersBalance _playersBalance;

        public PlayerFallCheckSystem()
        {
            _playersBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().PlayersBalance;
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