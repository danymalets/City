using Scellecs.Morpeh;

namespace Sources.App.Core.Ecs.Components.Car
{
    public struct ChangeSteeringAngleRequest : IComponent
    {
        public float AngleCoefficient;
    }
}