using Sources.Services.UiServices.WindowBase.Screens;
using UnityEngine;

namespace Sources.Services.UiServices.System
{
    public partial class UiViews : MonoBehaviour
    {
        [field: SerializeField] public GameScreen[] GameScreens { get; private set; }
    }
}