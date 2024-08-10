// using System.Collections.Generic;
// using System.Linq;
// using GameAnalyticsSDK;
// using UnityEngine;
//
// namespace Sources.Services.AnalyticsServices.Adapters
// {
//     public class GameAnalyticsAdapter : IAnalyticsAdapter, IGameAnalyticsATTListener
//     {
//         void IAnalyticsAdapter.Initialize()
//         {
//             if (Application.platform == RuntimePlatform.IPhonePlayer)
//             {
//                 GameAnalytics.RequestTrackingAuthorization(this);
//             }
//             else
//             {
//                 GameAnalytics.Initialize();
//             }
//             Debug.Log($"GameAnalyticsAdapter Initialize");
//         }
//
//         void IAnalyticsAdapter.SendEvent(string name, Dictionary<string, string> parameters)
//         {
//             Debug.Log($"GameAnalyticsAdapter SendEvent");
//
//             GameAnalytics.NewDesignEvent(name, parameters
//                 .ToDictionary(p => p.Key, p => (object)p.Value));
//         }
//
//         void IGameAnalyticsATTListener.GameAnalyticsATTListenerNotDetermined()
//         {
//             GameAnalytics.Initialize();
//         }
//
//         void IGameAnalyticsATTListener.GameAnalyticsATTListenerRestricted()
//         {
//             GameAnalytics.Initialize();
//         }
//
//         void IGameAnalyticsATTListener.GameAnalyticsATTListenerDenied()
//         {
//             GameAnalytics.Initialize();
//         }
//
//         void IGameAnalyticsATTListener.GameAnalyticsATTListenerAuthorized()
//         {
//             GameAnalytics.Initialize();
//         }
//     }
// }