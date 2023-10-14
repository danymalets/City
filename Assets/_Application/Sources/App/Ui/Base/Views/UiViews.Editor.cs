#if UNITY_EDITOR

namespace Sources.App.Ui.Base.Views
{
    public partial class UiViews
    {
        private void OnValidate()
        {
            GameScreens = GetComponentsInChildren<GameScreen>(true);
        }
    }
}

#endif
