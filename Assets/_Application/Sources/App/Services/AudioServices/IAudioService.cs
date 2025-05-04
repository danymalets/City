using Sources.App.Services.AssetsServices.Audio;
using Sources.Utils.Di;

namespace Sources.App.Services.AudioServices
{
    public interface IAudioService : IService
    {
        void PlayOnce(SoundType soundType);
        void PlayMusic(MusicType musicType);
        void StopAll();
    }
}