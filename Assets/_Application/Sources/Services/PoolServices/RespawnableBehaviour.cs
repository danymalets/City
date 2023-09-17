using UnityEngine;

namespace Sources.Services.PoolServices
{
    public class RespawnableBehaviour : MonoBehaviour, IRespawnable
    {
        RespawnableBehaviour IRespawnable.RespawnableBehaviour => this;
    }
}