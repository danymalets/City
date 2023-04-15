namespace Sources.App.Data.Players
{
    public interface IPlayerAnimator 
    {
        void SetMoveSpeed(float speed);
        void SetDie();
        void Setup();
    }
}