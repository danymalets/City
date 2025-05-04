using Sources.Services.PoolServices;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Audio
{
    public class AudioSourceView : RespawnableBehaviour
    {
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
    }
}