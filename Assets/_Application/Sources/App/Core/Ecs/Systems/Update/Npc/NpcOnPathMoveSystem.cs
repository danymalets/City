using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcCar;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.PlayersBalances;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Npc
{
    public class NpcOnPathMoveSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly PlayersBalance _playersBalance;

        public NpcOnPathMoveSystem()
        {
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath>().Without<PlayerInCar>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref PlayerTargetSpeed playerTargetSpeed = ref npcEntity.Get<PlayerTargetSpeed>();

                if (npcEntity.Has<ForwardBlockerRequest>() || npcEntity.Has<PathBlockerRequest>())
                {
                    playerTargetSpeed.Value = 0;
                }
                else
                {
                    playerTargetSpeed.Value = _playersBalance.NpcOnPathMaxSpeed;
                }
            }
        }
    }
}