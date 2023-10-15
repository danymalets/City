using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Ui.Base;
using Sources.App.Ui.Screens.LevelScreens;
using Sources.App.Ui.Screens.LevelScreens.CarInputScreens;
using Sources.App.Ui.Screens.LevelScreens.PlayerInputScreens;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class EnterCarButtonSwitcherSystem : DUpdateSystem
    {
        private readonly CarInputViewController _carInputView;
        private readonly PlayerInputViewController _playerInputView;

        private Filter _userWithoutCarFilter;

        public EnterCarButtonSwitcherSystem()
        {
            IUiControllersService uiControllers = DiContainer.Resolve<IUiControllersService>();

            LevelScreenController levelScreenController = uiControllers.Get<LevelScreenController>();

            _carInputView = levelScreenController.CarInputViewController;
            _playerInputView = levelScreenController.PlayerInputViewController;
        }

        protected override void OnInitFilters()
        {
            _userWithoutCarFilter = _world.Filter<UserTag>().Without<PlayerInCar>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_userWithoutCarFilter.TryGetSingle(out Entity entity))
            {
                _playerInputView.SetEnterButtonActive(entity.Has<CarInputPossibility>());
            }
        }
    }
}