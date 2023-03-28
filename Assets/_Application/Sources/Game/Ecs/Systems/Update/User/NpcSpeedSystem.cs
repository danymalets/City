using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities.Extensions;

namespace Sources.Game.Ecs.Systems.Update.User
{
    public class NpcSpeedSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly PlayersBalance _playerBalance;

        public NpcSpeedSystem()
        {
            _playerBalance = DiContainer.Resolve<Balance>().PlayersBalance;
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_filter.NoOne())
                return;

            foreach (Entity npcEntity in _filter)
            {
                ref RotationSpeed rotationSpeed = ref npcEntity.Get<RotationSpeed>();
            
                rotationSpeed.Value = _playerBalance.MaxRotationSpeed;
            }
        }
    }
}