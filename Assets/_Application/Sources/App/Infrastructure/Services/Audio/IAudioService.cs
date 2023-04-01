namespace Sources.App.Infrastructure.Services.Audio
{
    public interface IAudioService : IService
    {
        void PlayOnce(SoundEffectType soundEffectType);
        void PlayMusic(MusicType musicType);
        void StopAll();
    }
}