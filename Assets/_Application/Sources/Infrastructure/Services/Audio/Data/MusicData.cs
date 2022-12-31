using System;
using Sources.Data;
using Sources.Data.Live;

namespace Sources.Infrastructure.Services.Audio.Data
{
    [Serializable]
    public class MusicData : SoundData
    {
        public override LiveBool EnabledLiveBool =>
            Prefs.MusicEnabled;

        public override bool Loop => true;
        public override bool Stopable => true;
    }
}