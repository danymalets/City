using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.NavPathes;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class NpcSpeedSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly PlayersBalance _playerBalance;

        public NpcSpeedSystem()
        {
            _playerBalance = DiContainer.Resolve<Balance>().PlayersBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag>().Without<PlayerInCar, PLayerOnNavPath>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_filter.NoOne())
                return;

            foreach (Entity npcEntity in _filter)
            {
                ref RotationSpeed rotationSpeed = ref npcEntity.Get<RotationSpeed>();
            
                rotationSpeed.Value = _playerBalance.NpcMaxRotationSpeed;
            }
        }
    }
}