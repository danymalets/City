using Sources.Game.Ecs.Utils;

namespace Sources.Game.Ecs.Components.Views.Data
{
    public interface ICarData : IMonoComponent
    {
        float Mass { get; }
        float MaxSpeed { get; }
        float MaxMotorTorque { get; }
        float MaxSteeringAngle { get; }
    }
}