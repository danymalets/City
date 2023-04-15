using UnityEngine;

namespace Sources.CommonServices.PoolServices
{
    public class RespawnableBehaviour : MonoBehaviour, IRespawnable
    {

        RespawnableBehaviour IRespawnable.RespawnableBehaviour => this;
    }
}