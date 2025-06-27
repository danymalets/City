using System;
using Sources.Services.ScreenServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Ui.Common
{
    public class SafeArea : MonoBehaviour
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }

        private void OnValidate()
        {
            RectTransform = GetComponent<RectTransform>();
        }
    }
}