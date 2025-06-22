using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Sources.App.Ui.Screens.DebugMenuScreens.ExecutionItems;
using Sources.Services.GameObjectServices;
using Sources.Utils.Di;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus
{
    public class DebugExecutorController
    {
        private readonly DebugExecutorView _debugExecutorView;
        private readonly DebugExecutorItem _debugExecutorItem;
        private readonly IGameObjectService _gameObjectService;
        
        private readonly List<DebugFieldInputView> _debugFieldInputViews = new();
        private bool _hasRunningExecutor;

        public DebugExecutorController(DebugExecutorView debugExecutorView, DebugExecutorItem debugExecutorItem)
        {
            _debugExecutorView = debugExecutorView;
            _debugExecutorItem = debugExecutorItem;
            _gameObjectService = DiContainer.Resolve<IGameObjectService>();
        }

        public void Initialize()
        {
            _debugExecutorView.ExecuteButton.Text.text = _debugExecutorItem.ButtonName;
            _debugExecutorView.ResultText.text = "";
            
            foreach (var debugInputItem in _debugExecutorItem.Inputs) 
            {
                if (debugInputItem is DebugInputFieldItem debugInputFieldItem)
                {
                    var debugFieldInputView = _gameObjectService.Instantiate(_debugExecutorView.DebugFieldInputViewPrefab, _debugExecutorView.ContentParent);
                    debugFieldInputView.Title.text = $"{debugInputItem.Title}:";
                    debugFieldInputView.InputField.contentType = debugInputFieldItem.ContentType;
                    debugFieldInputView.InputField.text = debugInputFieldItem.DefaultValue.ToString();
                    _debugFieldInputViews.Add(debugFieldInputView);
                }
            }
            
            _debugExecutorView.ExecuteButton.Button.onClick.AddListener(OnExecuteButtonClicked);
        }
        
        private async void OnExecuteButtonClicked()
        {
            if (_hasRunningExecutor)
            {
                return;
            }

            _debugExecutorView.ExecuteButton.Button.interactable = false;
            _hasRunningExecutor = true;
            ViewResult(new DebugExecutorResult(DebugResultStatus.Waiting));
            var result = await _debugExecutorItem.Result(_debugFieldInputViews.Select(view => view.InputField.text).ToArray());
            ViewResult(result);
            await UniTask.WaitForSeconds(2f);
            ViewResult(new DebugExecutorResult(DebugResultStatus.End));
            _debugExecutorView.ExecuteButton.Button.interactable = true;
            _hasRunningExecutor = false;
        }

        public void Dispose()
        {
            _debugFieldInputViews.Clear();
            _debugExecutorView.ExecuteButton.Button.onClick.RemoveListener(OnExecuteButtonClicked);
            _gameObjectService.Destroy(_debugExecutorView.gameObject);
        }

        private void ViewResult(DebugExecutorResult result)
        {
            _debugExecutorView.ResultText.text = result.Message;
            
            _debugExecutorView.ResultText.color = result.ResultStatus switch
            {
                DebugResultStatus.Success => Color.green,
                DebugResultStatus.Waiting => Color.grey,
                DebugResultStatus.Failure => Color.red,
                DebugResultStatus.End => Color.black,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}