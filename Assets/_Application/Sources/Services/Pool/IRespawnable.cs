using System;
using UnityEngine;

namespace Sources.Services.Pool
{
    public interface IRespawnable
    {
        internal RespawnableBehaviour RespawnableBehaviour { get; }
    }
}