using System;
using System.Collections.Generic;
using Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.DebugExecutors;
using Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.ExecutionItems;
using Sources.Services.GameObjectServices;
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

        public void OnOpen(IEnumerable<DebugExecutorItem> debugExecutorItems)
        {
            foreach (var debugExecutorItem in debugExecutorItems)
            {
                var debugExecutorView = _gameObjectService.Instantiate(_debugMenuView.DebugExecutorViewPrefab, _debugMenuView.ContentParent);

                var debugExecutorController = new DebugExecutorController(debugExecutorView, debugExecutorItem);
                debugExecutorController.Initialize();
                _debugExecutorControllers.Add(debugExecutorController);
            }
        }

        public void OnClose()
        {
            foreach (var debugExecutorController in _debugExecutorControllers)
            {
                debugExecutorController.Dispose();
            }
        }
    }
}