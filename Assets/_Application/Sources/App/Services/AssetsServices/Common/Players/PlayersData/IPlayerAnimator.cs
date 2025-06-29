using Sources.App.Services.AssetsServices.Common.Cars.CarsData;

namespace Sources.App.Services.AssetsServices.Common.Players.PlayersData
{
    public interface IPlayerAnimator 
    {
        void SetMoveSpeed(float speed, bool isForce = false);
        void Die();
        void EnterCar(CarSideType sideType, bool isForce = false);
        void ExitCar(bool isForce = false);
    }
}