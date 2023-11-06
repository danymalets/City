using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Common.CustomToggles
{
    public class CustomToggle : MonoBehaviour
    {
        [field: SerializeField] public GameObject OnContent { get; private set; }
        [field: SerializeField] public GameObject OffContent { get; private set; }
        [field: SerializeField] public Button Button { get; private set; }
    }
}