using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;

namespace Sources.App.Core.Ecs.Aspects
{
    public struct PlayerPointAspect : IDAspect
    {
        public Entity Entity { get; set; }

        public readonly Vector3 GetPosition() =>
            Entity.TryGet(out PlayerInCar playerInCar)
                ? playerInCar.Car.GetAccess<ITransform>().Position
                : Entity.GetAccess<ITransform>().Position;
        
        public readonly Quaternion GetRotation() =>
            Entity.TryGet(out PlayerInCar playerInCar)
                ? playerInCar.Car.GetAccess<ITransform>().Rotation
                : Entity.GetAccess<ITransform>().Rotation;
    }
}