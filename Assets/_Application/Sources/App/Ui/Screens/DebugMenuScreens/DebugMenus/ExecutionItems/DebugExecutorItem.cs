using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.ExecutionItems.DepugInputsItems;

namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.ExecutionItems
{
    public class DebugExecutorItem
    {
        public string ButtonName { get; }
        public DebugInputItem[] Inputs { get; }
        public Func<string[], CancellationToken, UniTask<DebugExecutorResult>> Result { get; }
        
        public DebugExecutorItem(string buttonName, DebugInputItem[] inputs, Func<string[], CancellationToken, UniTask<DebugExecutorResult>> result)
        {
            ButtonName = buttonName;
            Inputs = inputs;
            Result = result;
        }
    }
}