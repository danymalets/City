using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.NavPathes;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.PlayersBalances;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class PlayerNavPathRotationSpeedSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly PlayersBalance _playerBalance;

        public PlayerNavPathRotationSpeedSystem()
        {
            _playerBalance = DiContainer.Resolve<Balance>().PlayersBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, PLayerOnNavPath>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ref RotationSpeed rotationSpeed = ref playerEntity.Get<RotationSpeed>();
                rotationSpeed.Value = _playerBalance.NavRotationSpeed;
            }
        }
    }
}