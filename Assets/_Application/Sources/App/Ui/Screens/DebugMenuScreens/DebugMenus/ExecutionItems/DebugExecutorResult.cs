namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.ExecutionItems
{
    public class DebugExecutorResult 
    {
        public DebugResultStatus ResultStatus { get; }
        public string Message { get; }
        
        public DebugExecutorResult(DebugResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        
        public DebugExecutorResult(DebugResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
            Message = resultStatus == DebugResultStatus.End ? "" : resultStatus.ToString();
        }
    }
}