using UnityEngine;

namespace Sources.App.Infrastructure.StateMachine.States.BootstrapStates
{
    public class BootstrapData : MonoBehaviour
    {
        [field: SerializeField] public MonoServicesData MonoServicesData { get; private set; }
        [field: SerializeField] public GameObject DebugMenu { get; private set; }
    }
}