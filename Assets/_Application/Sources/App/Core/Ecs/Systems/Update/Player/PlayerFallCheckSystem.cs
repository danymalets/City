using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.PlayersBalances;
using Sources.Utils.CommonUtils.Data;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerFallCheckSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly PlayersBalance _playersBalance;

        public PlayerFallCheckSystem()
        {
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, Collisions>().Without<Dead>().Build();
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