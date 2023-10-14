using Sources.App.Ui.Base.Views;
using TMPro;
using UnityEngine;

namespace Sources.App.Ui.Screens.PerformanceScreens
{
    public class PerformanceScreen : GameScreen
    {
        [field: SerializeField] public TextMeshProUGUI FpsText { get; private set; }

        [field: SerializeField] public TextMeshProUGUI InfoText { get; private set; }
    }
}