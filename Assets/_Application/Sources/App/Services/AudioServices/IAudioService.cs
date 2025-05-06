using Sources.App.Services.AssetsServices.Audio;
using Sources.Utils.Di;

namespace Sources.App.Services.AudioServices
{
    public interface IAudioService : IService
    {
        void SetSoundsGroupVolume(float volume);
        void SetMusicsGroupVolume(float volume);
        void PlayOnce(SoundType soundType);
        void PlayMusic(MusicType musicType);
        void StopAll();
    }
}