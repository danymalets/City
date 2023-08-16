using Sources.Services.ApplicationServices;
using Sources.Services.CoroutineRunnerServices;
using Sources.Services.FpsServices;
using Sources.Services.TimeServices;
using Sources.Services.UiServices.WindowBase.Screens;
using Sources.Utils.Di;
using TMPro;
using UnityEngine;

namespace Sources.App.Ui.Overlays
{
    public class PerformanceScreen : GameScreen
    {
        [field: SerializeField] public TextMeshProUGUI FpsText { get; private set; }

        [field: SerializeField] public TextMeshProUGUI InfoText { get; private set; }
    }
}