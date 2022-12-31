using System;
using System.Collections.Generic;
using System.Linq;
using Sources.UI.WindowBase;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.UI.System
{
    public class UiSystem : MonoBehaviour, ICloseableUIService
    {
        private static UiSystem _instance;

        [SerializeField]
        private Transform _windowsParent;

        private readonly Dictionary<Type, Window> _windows = new Dictionary<Type, Window>();
        private readonly HashSet<Window> _openWindows = new HashSet<Window>();
        
        public void Initialize()
        {
            _instance = this; 
            
            foreach (Transform windowTransform in _windowsParent)
            {
                Window window = windowTransform.GetComponent<Window>();
                GameObject fullScreenGameObject = windowTransform.gameObject;
                
                if (window == null)
                    throw new InvalidOperationException($"{fullScreenGameObject.name}" +
                                                        $" do not have Window component");

                window.gameObject.Disable();

                _windows.Add(window.GetType(), window);
            }

            foreach (Window window in _windows.Values)
            {
                window.SetupInternal();
                window.Opening += OnOpening;
                window.Closed += OnClosing;
            }
        }

        public void CloseAll()
        {
            foreach (Window window in _openWindows.ToArray())
                window.ForceClose();
        }
        
        public static TWindow Get<TWindow>() where TWindow : Window
        {
            if (_instance._windows.TryGetValue(typeof(TWindow), out Window window))
                return (TWindow)window;
            else
                throw new InvalidOperationException($"{typeof(TWindow)} not found");
        }
        
        private void OnOpening(Window window) => _openWindows.Add(window);

        private void OnClosing(Window window) => _openWindows.Remove(window);
    }
}