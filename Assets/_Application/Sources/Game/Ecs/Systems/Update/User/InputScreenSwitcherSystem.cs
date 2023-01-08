using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.UI.Screens.Input;
using Sources.UI.System;

namespace Sources.Game.Ecs.Systems.Update.User
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
                    _carInputScreen.Open(_world.GetUserEntity());

                if (_playerInputScreen.IsOpened)
                    _playerInputScreen.Close();
            }
            else
            {
                if (_carInputScreen.IsOpened)
                    _carInputScreen.Close();

                if (!_playerInputScreen.IsOpened)
                    _playerInputScreen.Open(_world.GetUserEntity());
            }
        }
    }
}