using System.Collections;
using Sources.Infrastructure.Services.CoroutineRunner;
using UnityEngine;

namespace Sources.Infrastructure.Services.Times
{
    public class TimeService : ITimeService
    {
        private const float Duration = 0.25f;
        
        private readonly ICoroutineRunnerService _coroutineRunner;
        private Coroutine _coroutine;
        
        private float _previousTimeScale;
        public bool IsTimeStopped { get; private set; }

        public TimeService()
        {
            _coroutineRunner = DiContainer.Resolve<ICoroutineRunnerService>();
        }
        
        public void StopTime()
        {
            IsTimeStopped = true;
            _previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        public void ReturnTime()
        {
            IsTimeStopped = false;
            Time.timeScale = _previousTimeScale;
        }

        public void SetTimeScale(float newTimeScale)
        {
            if (_coroutine != null)
                _coroutineRunner.StopCoroutine(_coroutine);
            
            _coroutine = _coroutineRunner.StartCoroutine(ChangeTimeScaleCoroutine(newTimeScale));
        }

        private IEnumerator ChangeTimeScaleCoroutine(float newTimeScale)
        {
            float startTimeScale = Time.timeScale;
            
            for (
                float elapsedTime = 0;
                elapsedTime < Duration;
                elapsedTime += IsTimeStopped ? 0 : Time.unscaledDeltaTime)
            {
                if (!IsTimeStopped)
                {
                    float progress = Mathf.Min(1f, elapsedTime / Duration);
                    Time.timeScale = Mathf.Lerp(startTimeScale, newTimeScale, progress);
                }
                yield return null;
            }
        }

        public void ResetTimeScale() => 
            SetTimeScale(1f);

    }
}