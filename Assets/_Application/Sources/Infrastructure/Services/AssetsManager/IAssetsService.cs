using Sources.Game.Characters;
using Sources.Game.GameObjects.Cars;

namespace Sources.Infrastructure.Services.AssetsManager
{
    public interface IAssetsService : IService
    {
        Car CarPrefab { get; }
        Npc NpcPrefab { get; }
        Player PlayerPrefab { get; }
    }
}