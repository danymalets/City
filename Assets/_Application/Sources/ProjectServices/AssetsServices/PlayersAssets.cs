using System.Collections.Generic;
using System.Linq;
using _Application.Sources.App.Data;
using _Application.Sources.App.Data.MonoEntities;
using _Application.Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.ProjectServices.AssetsServices
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