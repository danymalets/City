using Sources.Game.Ecs.Utils;

namespace Sources.Game.Ecs.Components.Views.PlayerDatas
{
    public interface IPlayerData : IMonoComponent
    {
        float Mass { get; }
        float Speed { get; }
        float MaxRotationSpeed { get; }
    }
}