using System.Collections;
using Sources.Infrastructure.Services.CoroutineRunner;
using UnityEngine;

namespace Sources.Infrastructure.Services.Times
{
    public class TimeService : ITimeService
    {
        public float Time => UnityEngine.Time.time;
        public float DeltaTime => UnityEngine.Time.deltaTime;
        public float FixedDeltaTime
        {
            get => UnityEngine.Time.fixedDeltaTime;
            set => UnityEngine.Time.fixedDeltaTime = value;
        }

        public float TimeScale
        {
            get => UnityEngine.Time.timeScale;
            set => UnityEngine.Time.timeScale = value;
        }
    }
}