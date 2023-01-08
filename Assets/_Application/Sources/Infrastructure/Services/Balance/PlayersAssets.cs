using System.Collections.Generic;
using System.Linq;
using Sources.Game.Ecs.MonoEntities;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(PlayersAssets), fileName = nameof(PlayersAssets))]
    public class PlayersAssets : ScriptableObject
    {
        [SerializeField]
        private PlayerInitData[] _carInitData;

        public IEnumerable<PlayerMonoEntity> PlayerPrefabs =>
            _carInitData.Select(d => d.PlayerPrefab);

        public PlayerMonoEntity GetRandomPlayer() =>
            _carInitData.GetRandomWithWights(d => (d.PlayerPrefab, d.Weight));
    }
}