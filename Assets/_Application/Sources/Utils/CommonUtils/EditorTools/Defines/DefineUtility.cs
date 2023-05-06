#if UNITY_EDITOR

using System.Linq;
using UnityEditor;
using UnityEditor.Build;

namespace Sources.Utils.CommonUtils.EditorTools.Defines
{
    public static class DefineUtility
    {
        public static void SetDefineEnabled(NamedBuildTarget buildTarget, string define, bool enabled)
        {
            string[] defines = GetDefinesForPlatform(buildTarget);

            defines = defines.Where(d => d != define).ToArray();

            if (enabled)
                defines = defines.Concat(new[] { define }).ToArray();

            PlayerSettings.SetScriptingDefineSymbols(buildTarget, defines);
        }

        private static string[] GetDefinesForPlatform(NamedBuildTarget buildTarget) =>
            PlayerSettings.GetScriptingDefineSymbols(buildTarget).Split(';');
    }
}

#endif