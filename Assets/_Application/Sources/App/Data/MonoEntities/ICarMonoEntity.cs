using System.Collections.Generic;
using Sources.App.Data.Cars;
using Sources.CommonServices.PoolServices;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Data.MonoEntities
{
    public interface ICarMonoEntity : IMonoEntity, IRespawnable
    {
        IEnableableGameObject EnableableGameObject { get; }
        IRigidbodySwitcher RigidbodySwitcher { get; }
        ITransform Transform { get; }
        IWheelsSystem WheelsSystem { get; }
        ICarEnterPoints EnterPoints { get; }
        ICarBorders BorderCollider { get; }
        IEnumerable<IEntityAccess> Colliders { get; }
        IEnumerable<IMeshRenderer> MeshRenderers { get; }
        Vector3 CenterRelatedRootPoint { get; }
        Vector3 HalfExtents { get; }
        Vector3 RootOffset { get; }
    }
}