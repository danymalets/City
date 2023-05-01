using System.Collections.Generic;
using System.Linq;
using Sources.App.Data;
using Sources.App.Data.MonoEntities;
using Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.App.Services.AssetsServices
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