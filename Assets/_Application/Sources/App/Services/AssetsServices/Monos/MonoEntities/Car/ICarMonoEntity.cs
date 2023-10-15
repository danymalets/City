using System.Collections.Generic;
using Sources.App.Data.Cars;
using Sources.Services.PoolServices;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;

namespace Sources.App.Services.AssetsServices.Monos.MonoEntities.Car
{
    public interface ICarMonoEntity : IMonoEntity
    {
        IEnableableGameObject EnableableGameObject { get; }
        IRigidbodySwitcher RigidbodySwitcher { get; }
        ITransform Transform { get; }
        IWheelsSystem WheelsSystem { get; }
        ICarEnterPoints EnterPoints { get; }
        ICarBorders BorderCollider { get; }
        IEnumerable<IEntityAccess> Colliders { get; }
        IEnumerable<IMeshRenderer> MeshRenderers { get; }
    }
}