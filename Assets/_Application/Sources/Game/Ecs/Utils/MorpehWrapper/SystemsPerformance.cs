using System.Collections.Generic;
using System.Linq;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class SystemsPerformance
    {
        private const int LogCount = 10;
        
        private readonly Dictionary<DUpdateSystem, long> _updateData = new();
        private readonly Dictionary<DUpdateSystem, long> _fixedData = new();

        public void WriteFixedData(DUpdateSystem fixedUpdateSystem, long ticks)
        {
            _fixedData.IncreaseValue(fixedUpdateSystem, ticks);
        }
        
        public void WriteUpdateData(DUpdateSystem updateSystem, long ticks)
        {
            if (updateSystem.GetType().Name.Contains("Gizmos"))
                return;
            
            _updateData.IncreaseValue(updateSystem, ticks);
        }

        public void LogData()
        {
            Debug.Log($"Fixed:\n\n{GetDebugText(_fixedData)}\n\n Update:\n\n{GetDebugText(_updateData)}");
        }

        private string GetDebugText(Dictionary<DUpdateSystem, long> data) => 
            string.Join("\n", GetSlowestSystems(data).Select(d => $"{d.system.GetType().Name} - {d.percent:R}%"));

        private IEnumerable<(DUpdateSystem system, float percent)> GetSlowestSystems(Dictionary<DUpdateSystem, long> data)
        {
            long sum = data.Values.Sum();
            return data.OrderByDescending(d => d.Value)
                .Take(LogCount).Select(d => (d.Key, (float)d.Value / sum * 100));
        }

        public void Reset()
        {
            _updateData.Clear();
            _fixedData.Clear();
        }
    }
}