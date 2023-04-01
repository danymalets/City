using System;
using System.Collections.Generic;
using Sources.Services.Ui.WindowBase;
using Sources.Services.Ui.WindowBase.Popups;
using Sources.Services.Ui.WindowBase.Screens;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.Services.Ui.System
{
    public class UiSystemData : MonoBehaviour
    {
        [Header("Roots")]
        [SerializeField]
        private Transform _screensRoot;

        [SerializeField]
        private Transform _popupsRoot;

        [SerializeField]
        private Transform _overlaysRoot;

        [Header("Content")]
        [SerializeField]
        private List<ScreenBase> _screens;

        [SerializeField]
        private List<PopupBase> _popups;

        [SerializeField]
        private List<ScreenBase> _overlays;
        
        private readonly Dictionary<Type, Window> _windows = new();

        public IEnumerable<ScreenBase> Screens => _screens;
        public IEnumerable<PopupBase> Popups => _popups;
        public IEnumerable<ScreenBase> Overlays => _overlays;

#if UNITY_EDITOR
        private void OnValidate()
        {
            ValidateWindows(_screensRoot, _screens);
            ValidateWindows(_popupsRoot, _popups);
            ValidateWindows(_overlaysRoot, _overlays);
        }

        private void ValidateWindows<T>(Transform root, ICollection<T> windows) where T : Window
        {
            windows.Clear();
            foreach (Transform windowTransform in root)
            {
                T window = windowTransform.GetComponent<T>();

                // if (window == null)
                //     throw new InvalidOperationException($"{windowTransform.gameObject.name}" +
                //                                         $" do not have {typeof(T)} component");
                //
                // if (windows.Any(w => w.GetType() == window.GetType()))
                //     throw new InvalidOperationException($"{window.GetType()}" +
                //                                         $" duplicate");
                
                windows.Add(window);
            }
        }
#endif
        
        public void Initialize()
        {
            Initialize(_screens);
            Initialize(_popups);
            Initialize(_overlays);
        }

        private void Initialize<T>(IEnumerable<T> windows) where T : Window
        {
            foreach (T window in windows)
            {
                window.gameObject.Disable();

                _windows.Add(window.GetType(), window);
            }
        }
        
        public TWindow Get<TWindow>() where TWindow : Window
        {
            if (_windows.TryGetValue(typeof(TWindow), out Window window))
                return (TWindow)window;
            else
                throw new InvalidOperationException($"{typeof(TWindow)} not found");
        }
    }
}