using static TMPro.TMP_InputField;

namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.ExecutionItems.DepugInputsItems
{
    public class DebugTextInputItem : DebugInputItem
    {
        public ContentType ContentType { get; }
        public long DefaultValue { get; }

        public DebugTextInputItem(string title, ContentType contentType, long defaultValue) : base(title)
        {
            ContentType = contentType;
            DefaultValue = defaultValue;
        }
    }
}