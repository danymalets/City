using System.Collections.Generic;
using Sources.Data.Cars;
using Sources.Services.Pool;
using Sources.Utils.DMorpeh;
using Sources.Utils.DMorpeh.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Data.MonoEntities
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