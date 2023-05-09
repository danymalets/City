using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Props;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.Utils.MorpehWrapper.DefaultComponents;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;

namespace Sources.App.Core.Ecs.Factories
{
    public class PropsFactory : Factory, IPropsFactory
    {
        public Entity Create(IPropsMonoEntity propsMonoEntity)
        {
            return _world.CreateFromMono(propsMonoEntity)
                .AllowFixedAwaiters()
                .TrackCollisions()
                .Add<PropsTag>()
                .AddIf<VerticalPropsTag>(() => propsMonoEntity.IsVertical)
                .SetIf(() => propsMonoEntity.IsVertical, new VerticalPoint
                    { Point = propsMonoEntity.VerticalPoint })
                .SetRef<ITransform>(propsMonoEntity.Transform)
                .SetRef<ICollider[]>(propsMonoEntity.Colliders.ToArray())
                .SetRef<IRigidbodySwitcher>(propsMonoEntity.RigidbodySwitcher)
                .SetRef<RigidbodySettings>(new RigidbodySettings(propsMonoEntity.Mass,
                    RigidbodyConstraints.None, propsMonoEntity.CenterOfMassPoint == null
                        ? null : propsMonoEntity.Transform.PointWorldToLocal(
                        propsMonoEntity.CenterOfMassPoint.Position)));
        }
    }
}