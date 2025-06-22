using Sources.App.Services.AssetsServices.Common.Monos.MonoEntities.Player;
using Sources.Services.SceneLoaderServices;
using UnityEngine;

namespace Sources.App.Infrastructure.StateMachine.States.MainUiStates
{
    public class PlayerRenderSceneContext : SceneContext
    {
        [field: SerializeField] public PlayerMonoEntity Player { get; private set; }
    }
}