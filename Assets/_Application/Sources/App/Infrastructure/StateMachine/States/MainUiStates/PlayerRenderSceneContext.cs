using Sources.App.Services.AssetsServices.Monos.MonoEntities.Player;
using Sources.Services.SceneLoaderServices;
using UnityEngine;

namespace Sources.App.Infrastructure.StateMachine.States.LevelStates
{
    public class PlayerRenderSceneContext : SceneContext
    {
        [field: SerializeField] public PlayerMonoEntity Player { get; private set; }
    }
}