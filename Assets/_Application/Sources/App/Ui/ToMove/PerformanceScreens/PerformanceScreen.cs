using Sources.Services.UiServices.WindowBase.Screens;
using TMPro;
using UnityEngine;

namespace Sources.App.Ui.ToMove.PerformanceScreens
{
    public class PerformanceScreen : GameScreen
    {
        [field: SerializeField] public TextMeshProUGUI FpsText { get; private set; }

        [field: SerializeField] public TextMeshProUGUI InfoText { get; private set; }
    }
}