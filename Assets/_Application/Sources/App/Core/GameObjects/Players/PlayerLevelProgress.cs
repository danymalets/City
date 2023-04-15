using System;
using System.Collections;
using UnityEngine;

namespace _Application.Sources.App.Core.GameObjects.Players
{
    public class PlayerLevelProgress : MonoBehaviour
    {
        private const float ProgressChangedInvokePeriod = 0.1f;
        
        public event Action<float> ProgressChanged = delegate { };
        public event Action Finished = delegate { };

        private float _sourceZ;
        private float _targetZ;

        private float _timer;

        public void Setup(float targetZ)
        {
            _sourceZ = transform.position.z;
            _targetZ = targetZ;

            StartCoroutine(ProgressCheckingCoroutine());
        }

        private IEnumerator ProgressCheckingCoroutine()
        {
            while (true)
            {
                yield return null;

                float progress = (transform.position.z - _sourceZ) / 
                                 (_targetZ - _sourceZ);

                _timer -= Time.deltaTime;
                if (_timer < 0)
                {
                    ProgressChanged(progress);
                    _timer = ProgressChangedInvokePeriod;
                }

                if (progress > 1)
                    break;
            }

            ProgressChanged(1);
            Finished();
        }
    }
}