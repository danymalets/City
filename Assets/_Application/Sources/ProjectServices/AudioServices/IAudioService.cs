using _Application.Sources.Utils.Di;

namespace Sources.ProjectServices.AudioServices
{
    public interface IAudioService : IService
    {
        void PlayOnce(SoundEffectType soundEffectType);
        void PlayMusic(MusicType musicType);
        void StopAll();
    }
}