using System;
using UnityEngine;

namespace Sources.Game.GameObjects.Cars
{
    [Serializable]
    public class AxleInfo {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor; 
        public bool steering;
    }
}