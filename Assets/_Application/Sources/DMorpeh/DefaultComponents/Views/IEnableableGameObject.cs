namespace Sources.DMorpeh.DefaultComponents.Views
{
    public interface IEnableableGameObject
    {
        void Enable();
        void Disable();
        void SetActive(bool isActive);
    }
}