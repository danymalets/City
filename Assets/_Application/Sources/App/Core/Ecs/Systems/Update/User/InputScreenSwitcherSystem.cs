using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Ui.Controllers;
using Sources.App.Ui.Screens.Input;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class InputScreenSwitcherSystem : DUpdateSystem
    {
        private readonly CarInputScreenController _carInputScreen;
        private readonly PlayerInputScreenController _playerInputScreen;

        private Filter _userWithCarFilter;
        private Filter _userWithoutCarFilter;
        
        public InputScreenSwitcherSystem()
        {
            IUiControllersService uiControllers = DiContainer.Resolve<IUiControllersService>();
            
            _carInputScreen = uiControllers.Get<CarInputScreenController>();
            _playerInputScreen = uiControllers.Get<PlayerInputScreenController>();
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
                if (!_carInputScreen.IsOpen)
                    _carInputScreen.Open();
            }
            else
            {
                if (_carInputScreen.IsOpen)
                    _carInputScreen.Close();

            }
            
            if (_userWithoutCarFilter.Any())
            {
                if (!_playerInputScreen.IsOpen)
                    _playerInputScreen.Open();
            }
            else
            {
                if (_playerInputScreen.IsOpen)
                    _playerInputScreen.Close();
            }
        }
    }
}