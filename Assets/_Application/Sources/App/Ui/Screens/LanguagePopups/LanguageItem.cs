using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.LanguagePopups
{
    public class LanguageItem : MonoBehaviour
    {
        [field: SerializeField] public Image Image { get; private set; }
        [field: SerializeField] public Button Button { get; private set; }
        [field: SerializeField] public GameObject SelectedGroup { get; private set; }
    }
}