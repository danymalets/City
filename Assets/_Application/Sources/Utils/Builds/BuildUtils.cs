#if UNITY_EDITOR


using System;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using Debug = UnityEngine.Debug;

namespace Sources.Utils.Builds
{
    public class BuildUtils
    {
        [MenuItem("MyTools/Android Build")]
        public static void BuildGame ()
        {
            
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = new string[] {"SplashScreen", "Bootstrap", "Empty", "City" }
                .Select(s => $"Assets/_Application/Scenes/{s}.unity").ToArray();

            buildPlayerOptions.target = BuildTarget.Android;
            buildPlayerOptions.locationPathName = $"build/Android/newproject-{DateTime.Now:dd-MM-yyyy-HH-mm-ss}.apk";

            buildPlayerOptions.options = BuildOptions.Development;
            
            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);

            BuildSummary summary = report.summary;
            
            if (summary.result == BuildResult.Succeeded)
            {
                Debug.Log($"OK");
            }
            else
            {
                Debug.Log($"NOT OK");
            }
        }
    }
}

#endif
