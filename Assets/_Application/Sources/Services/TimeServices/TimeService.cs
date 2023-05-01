using UnityEngine;

namespace Sources.Services.TimeServices
{
    public class TimeService : ITimeService
    {
        public float Time => UnityEngine.Time.time;
        public float DeltaTime => UnityEngine.Time.deltaTime;
        public float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime;
        
        public int PhysicsUpdateCount
        {
            get => Mathf.RoundToInt(1 / FixedDeltaTime);
            set => UnityEngine.Time.fixedDeltaTime = 1f / value;
        }
        
        public float TimeScale
        {
            get => UnityEngine.Time.timeScale;
            set => UnityEngine.Time.timeScale = value;
        }
    }
}