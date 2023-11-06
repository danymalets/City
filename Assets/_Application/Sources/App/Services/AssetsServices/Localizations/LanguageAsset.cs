using System;
using Sirenix.OdinInspector;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.PreferencesData;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Localizations
{
    [Serializable]
    public struct LanguageAsset
    {
        [field: Title("Type")]
        [field: SerializeField] public LanguageType LanguageType { get; private set; }
        [field: Title("Info")]
        
        [field: SerializeField] public string NameInEnglish { get; private set; }
        [field: SerializeField] public string NameInNative { get; private set; }
        [field: SerializeField] public string LanguageCode { get; private set; }
        [field: Title("Assets")]
        [field: SerializeField] public StringsAsset Strings { get; private set; }
        [field: SerializeField] public Sprite FlagSprite { get; private set; }
        [field: Title("Relevant Languages")]
        [field: SerializeField] public bool IsDefaultLanguage { get; private set; }
        [field: HideIf(nameof(IsDefaultLanguage))]
        [field: SerializeField] public SystemLanguage[] SystemLanguages { get; private set; }
    }
}