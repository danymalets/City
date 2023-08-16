using System;
using Sources.Services.UiServices.WindowBase.Screens;

#if UNITY_EDITOR

namespace Sources.Services.UiServices.System
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
