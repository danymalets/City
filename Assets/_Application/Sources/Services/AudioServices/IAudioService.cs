using Sources.Utils.Di;

namespace Sources.Services.AudioServices
{
    public interface IAudioService : IService
    {
        void PlayOnce(SoundEffectType soundEffectType);
        void PlayMusic(MusicType musicType);
        void StopAll();
    }
}