using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.CommonServices.UiServices.WindowBase.Screens;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.UI.Screens.Input
{
    public class CarInputScreen : Screen<Entity>
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

        protected override void OnOpen(Entity userEntity)
        {
            _userEntity = userEntity;
        }

        private void OnExitCarButtonClicked()
        {
            _userEntity.Add<PlayerWantsExitCar>();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.R))
            {
                _userEntity.Add<PlayerWantsExitCar>();
            }
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