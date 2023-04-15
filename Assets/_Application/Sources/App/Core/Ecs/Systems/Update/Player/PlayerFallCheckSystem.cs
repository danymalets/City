using System.Collections.Generic;
using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.Utils.CommonUtils.Data;
using _Application.Sources.Utils.CommonUtils.Libs;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using Sources.ProjectServices.BalanceServices;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Player
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