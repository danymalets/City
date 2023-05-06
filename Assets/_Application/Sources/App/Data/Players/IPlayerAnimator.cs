using Sources.App.Data.Cars;

namespace Sources.App.Data.Players
{
    public interface IPlayerAnimator 
    {
        void Setup();
        void SetMoveSpeed(float speed);
        void Die();
        void EnterCar(CarSideType sideType);
        void ExitCar();
    }
}