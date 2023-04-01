using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Infrastructure.Services;
using Sources.App.Infrastructure.Services.Balance;
using Sources.Utils.Extensions;

namespace Sources.App.Game.Ecs.Systems.Update.User
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