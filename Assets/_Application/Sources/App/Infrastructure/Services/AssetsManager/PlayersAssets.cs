using System.Collections.Generic;
using System.Linq;
using Sources.App.Game.Ecs.MonoEntities;
using Sources.App.Infrastructure.Services.Balance;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.App.Infrastructure.Services.AssetsManager
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(PlayersAssets), fileName = nameof(PlayersAssets))]
    public class PlayersAssets : ScriptableObject
    {
        [SerializeField]
        private List<PlayerData> _playerData;

        public IEnumerable<PlayerMonoEntity> PlayerPrefabs =>
            _playerData.Select(d => d.PlayerPrefab);

        private void OnValidate()
        {
            DValidate.OptimizeEnumsData(_playerData, 
                pd => pd.PlayerType, 
                pd => new PlayerData(pd));
        }

        public PlayerMonoEntity GetPlayerPrefab(PlayerType playerType) =>
            _playerData.First(pd => pd.PlayerType == playerType).PlayerPrefab;
    }
}