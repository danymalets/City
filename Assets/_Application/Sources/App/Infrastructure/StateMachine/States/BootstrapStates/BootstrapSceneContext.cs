using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.States.RegistationStates;
using Sources.Services.SceneLoaderServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Sources.App.Infrastructure.StateMachine.States.BootstrapStates
{
    [DefaultExecutionOrder(-100)]
    public class BootstrapSceneContext : SceneContext
    {
        [SerializeField]
        private BootstrapData _bootstrapData;
        
        private void Awake()
        {
            StartGameStateMachine();
        }

        private void StartGameStateMachine()
        {
            GameStateMachine gameStateMachine = new();
            gameStateMachine.Enter<RegistrationState, BootstrapData>(_bootstrapData);
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            Debug.Log("OnInit");
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
        }
    }
}