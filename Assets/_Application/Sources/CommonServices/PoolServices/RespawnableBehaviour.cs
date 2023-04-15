using UnityEngine;

namespace _Application.Sources.CommonServices.PoolServices
{
    public class RespawnableBehaviour : MonoBehaviour, IRespawnable
    {

        RespawnableBehaviour IRespawnable.RespawnableBehaviour => this;
    }
}