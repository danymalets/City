using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Application.Sources.CommonServices.UiServices.System
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(CanvasGroup))]
    public class StandardPopupAnimator : PopupAnimator
    {
        private static readonly Color FogColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        
        private const float OpenDuration = 0.3f;
        private const float OpenStartScale = 0.6f;
        private const float CloseDuration = 0.1f;
        private const float CloseEndScale = 1f;
        
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private Transform _content;

        private void OnValidate()
        {
            GetComponent<Image>().color = FogColor;
        }

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public override void Open(Action onOpened)
        {
            _canvasGroup.DOFade(1, OpenDuration)
                .From(0)
                .SetUpdate(true);

            _content.DOScale(Vector3.one, OpenDuration)
                .From(Vector3.one * OpenStartScale)
                .SetUpdate(true)
                .OnComplete(() => onOpened?.Invoke());
        }

        public override void Close(Action onClosed)
        {
            _canvasGroup.DOFade(0, CloseDuration)
                .From(1)
                .SetUpdate(true);

            _content.DOScale(Vector3.one * CloseEndScale, CloseDuration)
                .From(Vector3.one)
                .SetUpdate(true)
                .OnComplete(() => onClosed?.Invoke());
        }
    }
}