using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Services.UiServices.WindowBase.Screens;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;

namespace Sources.Services.UiServices.System
{
    public class UiViewsService : IInitializable, IUiViewsService
    {
        private readonly UiViews _uiViews;
        private Dictionary<Type, GameScreen> _dictionary;

        public UiViewsService(UiViews uiViews)
        {
            _uiViews = uiViews;
        }

        public void Initialize()
        {
            foreach (GameScreen gameScreen in _uiViews.GameScreens)
            {
                gameScreen.gameObject.Disable();
            }
            
            _dictionary = _uiViews.GameScreens.ToDictionary(w => w.GetType());
        }

        public TWindow Get<TWindow>() where TWindow : GameScreen
        {
            if (_dictionary.TryGetValue(typeof(TWindow), out GameScreen gameScreen))
            {
                return (TWindow)_dictionary[typeof(TWindow)];
            }
            else
            {
                throw new KeyNotFoundException($"No {typeof(TWindow)} window");
            }
        }
    }
}