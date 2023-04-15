using System.Linq;
using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.UI.Screens.Input;
using _Application.Sources.CommonServices.UiServices.System;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.User
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

        protected override void OnConstruct()
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