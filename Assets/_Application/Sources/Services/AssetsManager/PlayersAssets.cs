using System.Collections.Generic;
using System.Linq;
using Sources.Data;
using Sources.Data.MonoViews;
using Sources.Monos.MonoEntities;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.Services.AssetsManager
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(PlayersAssets), fileName = nameof(PlayersAssets))]
    public class PlayersAssets : ScriptableObject
    {
        [SerializeField]
        private List<PlayerAsset> _playerData;

        public IEnumerable<IPlayerMonoEntity> PlayerPrefabs =>
            _playerData.Select(d => d.PlayerPrefab);

        private void OnValidate()
        {
            DValidate.OptimizeEnumsData(_playerData, 
                pd => pd.PlayerType, 
                pd => new PlayerAsset(pd));
        }

        public IPlayerMonoEntity GetPlayerPrefab(PlayerType playerType) =>
            _playerData.First(pd => pd.PlayerType == playerType).PlayerPrefab;
    }
}