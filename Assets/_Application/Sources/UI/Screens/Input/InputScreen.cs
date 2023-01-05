using UnityEngine;
using Screen = Sources.UI.WindowBase.Screens.Screen;

namespace Sources.UI.Screens.Input
{
    public class InputScreen : Screen
    {
        [SerializeField]
        private GameplayButton _upButton;
        
        [SerializeField]
        private GameplayButton _downButton;
        
        [SerializeField]
        private GameplayButton _leftButton;

        [SerializeField]
        private GameplayButton _rightButton;

        public int VerticalInput => GetInputValue(_upButton, _downButton);
        public int HorizontalInput => GetInputValue(_rightButton, _leftButton);

        private int GetInputValue(GameplayButton positiveButton, GameplayButton negativeButton) => 
            positiveButton.PressValue - negativeButton.PressValue;
    }
}