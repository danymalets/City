using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.Input
{
    public class CarInputScreen : Sources.Services.UiServices.WindowBase.Screens.GameScreen
    {
        [SerializeField]
        private GameplayButton _upButton;
        
        [SerializeField]
        private GameplayButton _downButton;
        
        [SerializeField]
        private GameplayButton _leftButton;

        [SerializeField]
        private GameplayButton _rightButton;
        
        [SerializeField]
        private Button _exitCarButton;

        private Entity _userEntity;

        private void Awake()
        {
            _exitCarButton.onClick.AddListener(OnExitCarButtonClicked);
        }

        protected override void OnOpen()
        {
            DWorld world = DiContainer.Resolve<DWorld>();
            _userEntity = world.GetSingleton<UserTag>();
        }

        private void OnExitCarButtonClicked()
        {
            if (_userEntity.Has<PlayerFullyInCar>())
                _userEntity.Add<PlayerStartExitCarRequest>();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.R))
            {
                OnExitCarButtonClicked();
            }
            
            _exitCarButton.interactable = _userEntity.Has<PlayerFullyInCar>();
        }

        public int VerticalInput => GetInputValue(_upButton, _downButton);

        public int HorizontalInput => GetInputValue(_rightButton, _leftButton);

        private int GetInputValue(GameplayButton positiveButton, GameplayButton negativeButton) => 
            positiveButton.PressValue - negativeButton.PressValue;

        protected override void OnClose()
        {
            _userEntity = null;
        }
    }
}