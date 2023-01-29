using Sources.Game.Ecs.Utils;

namespace Sources.Game.Ecs.Components.Views.Camera
{
    public interface ICameraData : IMonoComponent
    {
        float FieldOfView { get; set; }
    }
}