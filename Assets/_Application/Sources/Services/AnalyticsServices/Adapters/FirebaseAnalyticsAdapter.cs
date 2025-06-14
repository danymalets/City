// using System.Collections.Generic;
// using System.Linq;
// using Firebase.Extensions;
// using UnityEngine;
//
// namespace Sources.Services.AnalyticsServices.Adapters
// {
//     public class FirebaseAnalyticsAdapter : IAnalyticsAdapter
//     {
//         public void Initialize()
//         {
//             Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
//             {
//                 var dependencyStatus = task.Result;
//                 if (dependencyStatus == Firebase.DependencyStatus.Available)
//                 {
//                     Debug.Log($"[FirebaseAnalytics] Initialized");
//
//                     var app = Firebase.FirebaseApp.DefaultInstance;
//                 }
//                 else
//                 {
//                     Debug.Log($"[FirebaseAnalytics] Could not resolve all Firebase dependencies: {dependencyStatus}");
//                 }
//             });
//         }
//
//         public void SendEvent(string name, Dictionary<string, string> parameters)
//         {
//             Firebase.Analytics.FirebaseAnalytics.LogEvent(name, 
//                 parameters.Select(p => new Firebase.Analytics.Parameter(
//                     p.Key, p.Value)).ToArray());
//         }
//     }
// }