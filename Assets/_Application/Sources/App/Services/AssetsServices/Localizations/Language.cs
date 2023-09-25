using System;
using Sources.App.Services.UserServices;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Localizations
{
    [Serializable]
    public struct Language
    {
        [field: SerializeField] public LanguageType Type { get; private set; }
        [field: SerializeField] public SystemLanguage[] SystemLanguages { get; private set; }
        [field: SerializeField] public string NameInEnglish { get; private set; }
        [field: SerializeField] public string NameInNative { get; private set; }
        [field: SerializeField] public string LanguageCode { get; private set; }
        [field: SerializeField] public StringsAsset Strings { get; private set; }
    }
}