using UnityEngine;

namespace Sources.App.Ui.Base.Views
{
    public partial class UiViews : MonoBehaviour
    {
        [field: SerializeField] public GameScreen[] GameScreens { get; private set; }
    }
}