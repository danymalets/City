using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.Utils.CommonUtils.Extensions;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using Sources.ProjectServices.BalanceServices;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.User
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