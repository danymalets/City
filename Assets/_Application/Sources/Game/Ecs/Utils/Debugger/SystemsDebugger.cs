using Sources.Game.Ecs.Utils.Debugger.Components;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.Debugger
{
    public class SystemsDebugger : MonoBehaviour
    {
        public static SystemsDebugData SystemsDebugData;

        public void UpdateSystemsData(SystemsDebugData systemsDebugData)
        {
            SystemsDebugData = systemsDebugData;
        }
    }
}