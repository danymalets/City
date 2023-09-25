using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Common
{
    public class TextButton : MonoBehaviour
    {
        [field: SerializeField] public Button Button { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Text { get; private set; }
    }
}