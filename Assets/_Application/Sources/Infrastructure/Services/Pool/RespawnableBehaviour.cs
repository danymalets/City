using System;
using UnityEngine;

namespace Sources.Infrastructure.Services.Pool
{
    public class RespawnableBehaviour : MonoBehaviour
    {
        public event Action<RespawnableBehaviour> Despawned = delegate { };

        public void Despawn()
        {    
            OnDespawn();
            gameObject.SetActive(false);
            Despawned(this);
        }

        protected virtual void OnDespawn()
        {
        }
    }
}