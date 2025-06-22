using System;
using System.Collections.Generic;
using Sources.Services.InstantiatorServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus
{
    public class DebugMenuViewController
    {
        private readonly DebugMenuView _debugMenuView;
        private readonly IGameObjectService _gameObjectService;
        private readonly List<DebugExecutorController> _debugExecutorControllers = new();

        public DebugMenuViewController(DebugMenuView debugMenuView)
        {
            _debugMenuView = debugMenuView;
            _gameObjectService = DiContainer.Resolve<IGameObjectService>();
        }

        public void Initialize(IEnumerable<DebugExecutorItem> debugExecutorItems)
        {
            foreach (var debugExecutorItem in debugExecutorItems)
            {
                var debugExecutorView = _gameObjectService.Instantiate(_debugMenuView.DebugExecutorViewPrefab, _debugMenuView.ContentParent);

                var debugExecutorController = new DebugExecutorController(debugExecutorView, debugExecutorItem);
                debugExecutorController.Initialize();
                _debugExecutorControllers.Add(debugExecutorController);
            }
        }

        public void Dispose()
        {
            foreach (var debugExecutorController in _debugExecutorControllers)
            {
                debugExecutorController.Dispose();
            }
        }
    }
}