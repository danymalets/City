using System;
using Cysharp.Threading.Tasks;

namespace Sources.App.Ui.Screens.DebugMenuScreens
{
    public class DebugExecutorItem
    {
        public string ButtonName { get; }
        public DebugInputItem[] Inputs { get; }
        public Func<string[], UniTask<DebugExecutorResult>> Result { get; }
        
        public DebugExecutorItem(string buttonName, DebugInputItem[] inputs, Func<string[], UniTask<DebugExecutorResult>> result)
        {
            ButtonName = buttonName;
            Inputs = inputs;
            Result = result;
        }
    }
}