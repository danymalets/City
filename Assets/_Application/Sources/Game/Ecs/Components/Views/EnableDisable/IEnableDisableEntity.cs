using Sources.Game.Ecs.Utils;

namespace Sources.Game.Ecs.Components.Views.EnableDisable
{
    public interface IEnableDisableEntity : IMonoComponent
    { 
        void Enable();
        void Disable();
    }
}