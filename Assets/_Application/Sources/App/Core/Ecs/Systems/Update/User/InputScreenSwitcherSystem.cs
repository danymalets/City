using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Ui.Screens.Input;
using Sources.Services.UiServices.System;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class InputScreenSwitcherSystem : DUpdateSystem
    {
        private readonly CarInputScreen _carInputScreen;
        private readonly PlayerInputScreen _playerInputScreen;

        private Filter _userWithCarFilter;
        private Filter _userWithoutCarFilter;
        public InputScreenSwitcherSystem()
        {
            IUiService ui = DiContainer.Resolve<IUiService>();
            
            _carInputScreen = ui.Get<CarInputScreen>();
            _playerInputScreen = ui.Get<PlayerInputScreen>();
        }

        protected override void OnInitFilters()
        {
            _userWithCarFilter = _world.Filter<UserTag, PlayerInputInCarOn>();
            _userWithoutCarFilter = _world.Filter<UserTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_userWithCarFilter.Any())
            {
                if (!_carInputScreen.IsOpened)
                    _carInputScreen.Open();
            }
            else
            {
                if (_carInputScreen.IsOpened)
                    _carInputScreen.Close();

            }
            
            if (_userWithoutCarFilter.Any())
            {
                if (!_playerInputScreen.IsOpened)
                    _playerInputScreen.Open();
            }
            else
            {
                if (_playerInputScreen.IsOpened)
                    _playerInputScreen.Close();
            }
        }
    }
}