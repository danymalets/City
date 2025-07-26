using Sources.Services.SceneLoaderServices;
using UnityEngine;

namespace Sources.App.Infrastructure.StateMachine.States.MainUiStates
{
    public class PlayerRenderSceneContext : SceneContext
    {
        [field: SerializeField] public Transform Player { get; private set; }
    }
}