using static TMPro.TMP_InputField;

namespace Sources.App.Ui.Screens.DebugMenuScreens.ExecutionItems
{
    public class DebugInputFieldItem : DebugInputItem
    {
        public ContentType ContentType { get; }
        public long DefaultValue { get; }

        public DebugInputFieldItem(string title, ContentType contentType, long defaultValue) : base(title)
        {
            ContentType = contentType;
            DefaultValue = defaultValue;
        }
    }
}