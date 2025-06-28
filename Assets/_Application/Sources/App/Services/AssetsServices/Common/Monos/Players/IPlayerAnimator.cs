using Sources.App.Services.AssetsServices.Common.Monos.Cars;

namespace Sources.App.Services.AssetsServices.Common.Monos.Players
{
    public interface IPlayerAnimator 
    {
        void SetMoveSpeed(float speed, bool isForce = false);
        void Die();
        void EnterCar(CarSideType sideType, bool isForce = false);
        void ExitCar(bool isForce = false);
    }
}