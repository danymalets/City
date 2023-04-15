namespace _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views
{
    public interface IEnableableGameObject
    {
        void Enable();
        void Disable();
        void SetActive(bool isActive);
    }
}