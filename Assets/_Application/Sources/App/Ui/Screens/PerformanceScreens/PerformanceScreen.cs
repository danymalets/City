using Sources.App.Ui.Base.Views;
using TMPro;
using UnityEngine;

namespace Sources.App.Ui.Screens.PerformanceScreens
{
    public class PerformanceScreen : GameScreen
    {
        [field: SerializeField] public TextMeshProUGUI FpsValueText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI TargetFrameRateValueText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI PhysicsUpdateCountValueText { get; private set; }
    }
}