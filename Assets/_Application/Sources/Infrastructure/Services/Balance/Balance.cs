using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    public class Balance : MonoBehaviour, IService
    {
        [SerializeField]
        private CameraBalance _cameraBalance;

        
        
        public CameraBalance CameraBalance => _cameraBalance;
    }   
}