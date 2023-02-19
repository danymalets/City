using Sources.Game.Ecs.Utils;

namespace Sources.Game.Ecs.Components.Views.EnableDisable
{
    public interface IEnableableEntity : IMonoComponent
    { 
        void Enable();
        void Disable();
    }
}