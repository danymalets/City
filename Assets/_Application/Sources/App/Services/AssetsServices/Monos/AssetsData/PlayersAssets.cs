using System.Collections.Generic;
using System.Linq;
using Sources.App.Data.Players;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.App.Services.AssetsServices.Monos.MonoEntities.Player;
using Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.AssetsData
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
            DValidate.ValidateEnumsData(_playerData, 
                pd => pd.PlayerType, 
                pd => new PlayerAsset(pd));
        }

        public IPlayerMonoEntity GetPlayerPrefab(PlayerType playerType) =>
            _playerData.First(pd => pd.PlayerType == playerType).PlayerPrefab;
    }
}