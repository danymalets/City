#if UNITY_EDITOR

using System;
using Sirenix.OdinInspector;
using UnityEditor.Build;
using UnityEngine;

namespace Sources.Utils.CommonUtils.EditorTools.Defines
{
    [Serializable]
    public class DefineGroup
    {
        [SerializeField]
        private string _define;

        [Space(5)]

        [OnValueChanged(nameof(OnAllPlatformsChanged))]
        [SerializeField]
        private bool _allPlatforms;
        
        [Space(5)]
        [OnValueChanged(nameof(OnStandaloneChanged))]
        [SerializeField]
        private bool _standalone;
        
        [OnValueChanged(nameof(OnAndroidChanged))]
        [SerializeField]
        private bool _android;
        
        [OnValueChanged(nameof(OnIosChanged))]
        [SerializeField]
        private bool _ios;

        private void OnAllPlatformsChanged()
        {
            _standalone = _allPlatforms;
            OnStandaloneChanged();
            
            _android = _allPlatforms;
            OnAndroidChanged();

            _ios = _allPlatforms;
            OnIosChanged();

            Debug.Log($"suc");
        }

        private void OnStandaloneChanged() =>
            DefineUtility.SetDefineEnabled(NamedBuildTarget.Standalone, _define, _standalone);

        private void OnAndroidChanged() =>
            DefineUtility.SetDefineEnabled(NamedBuildTarget.Android, _define, _android);

        private void OnIosChanged() =>
            DefineUtility.SetDefineEnabled(NamedBuildTarget.iOS, _define, _ios);
    }
}

#endif