using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.UI.Screens.Input;
using Sources.CommonServices.UiServices.System;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class InputScreenSwitcherSystem : DUpdateSystem
    {
        private Filter _userWithCar;
        
        private readonly CarInputScreen _carInputScreen;
        private readonly PlayerInputScreen _playerInputScreen;

        public InputScreenSwitcherSystem()
        {
            IUiService ui = DiContainer.Resolve<IUiService>();
            
            _carInputScreen = ui.Get<CarInputScreen>();
            _playerInputScreen = ui.Get<PlayerInputScreen>();
        }

        protected override void OnInitFilters()
        {
            _userWithCar = _world.Filter<UserTag, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_userWithCar.Any())
            {
                if (!_carInputScreen.IsOpened)
                    _carInputScreen.Open(_world.GetSingletonEntity<UserTag>());

                if (_playerInputScreen.IsOpened)
                    _playerInputScreen.Close();
            }
            else
            {
                if (_carInputScreen.IsOpened)
                    _carInputScreen.Close();

                if (!_playerInputScreen.IsOpened)
                    _playerInputScreen.Open(_world.GetSingletonEntity<UserTag>());
            }
        }
    }
}