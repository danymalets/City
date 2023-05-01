using Sources.App.Services.AudioServices;
using Sources.Utils.CommonUtils.Data.Live;
using Sources.Utils.Di;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Popups.Settings
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    public class SwitchableButton : MonoBehaviour
    {
        private static readonly Color EnabledColor = Color.white;
        private static readonly Color DisabledColor = Color.grey;

        [SerializeField]
        private bool _debugMark;

        private Image _image;
        private Button _button;
        private IAudioService _audio;

        protected LiveBool _liveBool;

        private void OnValidate()
        {
            GetComponent<Image>().color = _debugMark ? EnabledColor : DisabledColor;
        }

        private void Awake()
        {
            _image = GetComponent<Image>();
            _button = GetComponent<Button>();
        }

        public void Setup(LiveBool liveBool)
        {
            _liveBool = liveBool;
            _image.color = liveBool.Value ? EnabledColor : DisabledColor;
            
            _button.onClick.AddListener(OnButtonClicked);
            _liveBool.Changed += OnValueChanged; 
            
            _audio = DiContainer.Resolve<IAudioService>();
        }

        private void OnButtonClicked()
        {
            _audio.PlayOnce(SoundEffectType.ButtonClick);
            _liveBool.Value = !_liveBool.Value;
        }

        private void OnValueChanged(bool newValue)
        {
            _image.color = newValue ? EnabledColor : DisabledColor;
        }

        public void Cleanup()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
            _liveBool.Changed -= OnValueChanged;
        }
    }
}