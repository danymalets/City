namespace Sources.App.Ui.Common.ToggleableImages
{
    public class ToggleableImageController
    {
        private readonly ToggleableImage _toggleableImage;

        public ToggleableImageController(ToggleableImage toggleableImage)
        {
            _toggleableImage = toggleableImage;
        }

        public void SetEnabled(bool isEnabled)
        {
            _toggleableImage.Image.sprite = isEnabled ? _toggleableImage.OnSprite : _toggleableImage.OffSprite;
        }
    }
}