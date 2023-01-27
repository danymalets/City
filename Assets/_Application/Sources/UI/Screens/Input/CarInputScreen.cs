using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.UI.WindowBase.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Screens.Input
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
            Debug.Log($"exit");
            _userEntity.Add<PlayerWantsExitCar>();
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