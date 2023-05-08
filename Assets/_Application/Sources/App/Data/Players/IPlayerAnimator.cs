using Sources.App.Data.Cars;

namespace Sources.App.Data.Players
{
    public interface IPlayerAnimator 
    {
        void SetMoveSpeed(float speed, bool isForce = false);
        void Die();
        void EnterCar(CarSideType sideType, bool isForce);
        void ExitCar();
    }
}