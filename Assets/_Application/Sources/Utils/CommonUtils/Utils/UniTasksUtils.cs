using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;

namespace Sources.Utils.CommonUtils.Libs
{
    public static class UniTasksUtils
    {
        public static void RunEachUpdate(Action updateAction, CancellationToken cancellationToken = default) =>
            UniTaskAsyncEnumerable.EveryUpdate().ForEachAsync(_ => updateAction(), cancellationToken).Forget();
        
        private static void RunEachSeconds(float period, Action action, bool andNow, CancellationToken cancellationToken = default)
        {
            var timer = andNow ? 0 : period;
            
            RunEachUpdate(() =>
            {
                
            }, cancellationToken);
        }
    }
}