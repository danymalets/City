using Sources.Infrastructure.Bootstrap.InstallersBase;
using Sources.Infrastructure.Services.Audio;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap.Installers
{
    public class AudioInstaller : MonoServiceInstaller<AudioService, IAudioService>
    {
        public AudioInstaller(Transform parent) : base(parent)
        {
        }

        protected override void Setup(AudioService audio)
        {
            audio.Setup();
        }
    }
}