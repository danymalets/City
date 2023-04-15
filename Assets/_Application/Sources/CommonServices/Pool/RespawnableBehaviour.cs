using System;
using UnityEngine;

namespace Sources.Services.Pool
{
    public class RespawnableBehaviour : MonoBehaviour, IRespawnable
    {

        RespawnableBehaviour IRespawnable.RespawnableBehaviour => this;
    }
}