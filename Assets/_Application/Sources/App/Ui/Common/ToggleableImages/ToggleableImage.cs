using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Common.ToggleableImages
{
    public class ToggleableImage : MonoBehaviour
    {
        [field: SerializeField] public Image Image { get; private set; }
        [field: SerializeField] public Sprite OnSprite { get; private set; }
        [field: SerializeField] public Sprite OffSprite { get; private set; }
    }
}