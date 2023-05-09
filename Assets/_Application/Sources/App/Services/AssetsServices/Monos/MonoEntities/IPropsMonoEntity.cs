using System.Collections.Generic;
using Sources.App.Data.Points;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.MonoEntities
{
    public interface IPropsMonoEntity : IMonoEntity
    {
        IEnumerable<ICollider> Colliders { get; }
        float Mass { get; }
        IEnumerable<IPropsMonoEntity> DerivedProps { get; }
        IRigidbodySwitcher RigidbodySwitcher { get; }
        ITransform Transform { get; }
        IPoint CenterOfMassPoint { get; }
        IPoint VerticalPoint { get; }
        bool IsVertical { get; }
    }
}