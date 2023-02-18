#if UNITY_EDITOR

using Sources.Game.Constants;
using Sources.Infrastructure.Bootstrap;
using UnityEditor;
using UnityEngine;

namespace Sources.PseudoEditor
{
    public static class DEditor
    {
        public static MonoServices EditorServices =>
            AssetDatabase.LoadAssetAtPath<MonoServices>(Pathes.MonoServicesPath);

        public static T InstantiatePrefab<T>(T prefab) where T : MonoBehaviour =>
            PrefabUtility.InstantiatePrefab(prefab) as T;

        public static T InstantiatePrefab<T>(T prefab, Transform parent) where T : MonoBehaviour
        {
            T obj = InstantiatePrefab(prefab);
            obj.transform.SetParent(parent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            return obj;
        }

    }
}

#endif