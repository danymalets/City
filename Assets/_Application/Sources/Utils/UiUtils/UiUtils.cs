namespace Sources.Utils.UiUtils
{
    public static class UiUtils
    {
        public static int GetInputValue(GameplayButton positiveButton, GameplayButton negativeButton) =>
            positiveButton.PressValue - negativeButton.PressValue;
    }
}