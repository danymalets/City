namespace Sources.App.Data.Players
{
    public interface IPlayerAnimator 
    {
        void SetMoveSpeed(float speed);
        void SetDie();
        void Setup();
        void SetInCarLeft(bool value);
        void SetInCarRight(bool value);
    }
}