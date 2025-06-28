using System.Collections.Generic;
using System.Linq;
using Sources.App.Services.AssetsServices.Common.Monos.MonoEntities.Player;
using Sources.App.Services.AssetsServices.Common.Monos.Players;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Monos.AssetsData
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(PlayersAssets), fileName = nameof(PlayersAssets))]
    public class PlayersAssets : ScriptableObject
    {
        [SerializeField]
        private List<PlayerAsset> _playerData;

        public IEnumerable<PlayerMonoEntity> PlayerPrefabs =>
            _playerData.Select(d => d.PlayerPrefab);

        public PlayerMonoEntity GetPlayerPrefab(PlayerType playerType) =>
            _playerData.First(pd => pd.PlayerType == playerType).PlayerPrefab;
    }
}