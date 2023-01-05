using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    public class BalanceService : MonoBehaviour, IBalanceService
    {
        [SerializeField]
        private CameraBalance _cameraBalance;

        public CameraBalance CameraBalance => _cameraBalance;
    }   
}