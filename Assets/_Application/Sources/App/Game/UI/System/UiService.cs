using System.Collections.Generic;
using System.Linq;
using Sources.App.Game.UI.WindowBase;
using Sources.App.Game.UI.WindowBase.Popups;
using Sources.App.Game.UI.WindowBase.Screens;
using Sources.Di;
using Sources.Services.ApplicationCycle;
using UnityEngine;
using UnityEngine.Assertions;

namespace Sources.App.Game.UI.System
{
    public class UiService : MonoBehaviour, IUiService, IUiRefreshService, IUiCloseService, IInitializable
    {
        [SerializeField]
        private UiSystemData _uiSystemData;

        private readonly HashSet<ScreenBase> _openScreens = new();
        private readonly Stack<PopupBase> _openPopups = new();
        
        public void Initialize()
        {
            IApplicationService applicationService = DiContainer.Resolve<IApplicationService>();
            applicationService.BackButtonClicked += Application_BackButtonClicked;
            
            _uiSystemData.Initialize();
            
            foreach (ScreenBase screen in _uiSystemData.Screens)
            {
                screen.SetupInternal(this);
                screen.Opening += OnScreenOpening;
                screen.Closed += OnScreenClosed;
            }
            
            foreach (PopupBase popup in _uiSystemData.Popups)
            {
                popup.SetupInternal(this);
                popup.Opening += OnPopupOpening;
                popup.Closed += OnPopupClosed;
            }
            
            foreach (ScreenBase overlay in _uiSystemData.Overlays)
            {
                overlay.SetupInternal(this);
            }
        }

        private void Application_BackButtonClicked() => 
            TryCloseTopPopup();

        private void TryCloseTopPopup()
        {
            if (_openPopups.Any())
            {
                PopupBase popup = _openPopups.Pop();
                popup.Close();
            }
        }

        public void CloseAll()
        {
            while (_openPopups.Any())
            {
                PopupBase popup = _openPopups.Pop();
                popup.Close();
            }
            
            foreach (ScreenBase screen in _openScreens.ToArray()) 
                screen.ForceClose();
        }

        public TWindow Get<TWindow>() where TWindow : Window => 
            _uiSystemData.Get<TWindow>();

        public Window Open<TWindow>() where TWindow : Window, IWindow =>
            Get<TWindow>().Open();

        public void Refresh()
        {
            foreach (ScreenBase screen in _openScreens)
                screen.Refresh();
            
            foreach (PopupBase popup in _openPopups)
                popup.Refresh();
        }

        private void OnScreenOpening(Window screen) => _openScreens.Add((ScreenBase)screen);
        private void OnScreenClosed(Window screen) => _openScreens.Remove((ScreenBase)screen);
        
        private void OnPopupOpening(Window popup) => _openPopups.Push((PopupBase)popup);

        private void OnPopupClosed(Window popup)
        {
            Assert.IsTrue(_openPopups.Any());
            Assert.IsTrue(_openPopups.Peek() == (PopupBase)popup);

            _openPopups.Pop();
        }
    }
}