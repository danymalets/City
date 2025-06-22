using Sources.App.Ui.Common;
using TMPro;
using UnityEngine;

namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus
{
    public class DebugExecutorView : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI ResultText { get; private set; }
        [field: SerializeField] public TextButton ExecuteButton { get; private set; }
        [field: SerializeField] public Transform ContentParent { get; private set; }
        [field: SerializeField] public DebugFieldInputView DebugFieldInputViewPrefab { get; private set; }
    }
}