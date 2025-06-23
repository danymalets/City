using TMPro;
using UnityEngine;

namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.DebugExecutors.DebugInputFields
{
    public class DebugFieldInputView : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI Title { get; private set; }
        [field: SerializeField] public TMP_InputField InputField { get; private set; }
    }
}