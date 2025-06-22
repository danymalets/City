using UnityEngine;

namespace Sources.App.Services.AssetsServices
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(ScenesAssets), fileName = nameof(ScenesAssets))]
    public class ScenesAssets : ScriptableObject
    {
        [field: SerializeField] public string PlayerRenderSceneName { get; private set; } = "PlayerRender";
        [field: SerializeField] public string CitySceneName { get; private set; } = "City";
    }
}