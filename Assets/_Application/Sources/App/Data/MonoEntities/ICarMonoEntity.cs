using System.Collections.Generic;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.CommonServices.PoolServices;
using _Application.Sources.Utils.MorpehWrapper;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace _Application.Sources.App.Data.MonoEntities
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