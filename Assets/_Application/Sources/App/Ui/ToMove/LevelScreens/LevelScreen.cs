using System;
using Sources.App.Services.AudioServices;
using Sources.Services.UiServices.WindowBase.Screens;
using Sources.Utils.Di;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.Level
{
    public class LevelScreen : GameScreen
    {
        [field: SerializeField] public Button ExitButton { get; private set; }
        [field: SerializeField] public Button RestartButton { get; private set; }
        [field: SerializeField] public CoinsView CoinsView { get; private set; }
    }
}