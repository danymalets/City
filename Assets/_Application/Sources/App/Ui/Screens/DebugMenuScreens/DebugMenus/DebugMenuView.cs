using Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus.DebugExecutors;
using TMPro;
using UnityEngine;

namespace Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus
{
    public class DebugMenuView : MonoBehaviour
    {
        [field: SerializeField] public DebugExecutorView DebugExecutorViewPrefab { get; private set; }
        [field: SerializeField] public Transform ContentParent { get; private set; }
    }
}