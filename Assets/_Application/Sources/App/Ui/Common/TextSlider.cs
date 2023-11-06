using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Common
{
    public class TextSlider : MonoBehaviour
    {
        [field: SerializeField] public Slider Slider { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Text { get; private set; }
    }
}