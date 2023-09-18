using System.Collections.Generic;
using System.Linq;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.MorpehUtils
{
    public class SystemsPerformance
    {
        private const int LogCount = 10;
        
        private readonly Dictionary<DUpdateSystem, long> _updateData = new();
        private readonly Dictionary<DUpdateSystem, long> _fixedData = new();
        private int _fixeds;
        private int _updates;

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
            float updateMs = (float)_updateData.Values.Sum() / 10_000 / _updates;
            float fixedMs = (float)_fixedData.Values.Sum() / 10_000 / _fixeds;

            string text = $"Fixed(avg={fixedMs}ms):\n\n{GetDebugText(_fixedData)}\n\n" +
                          $"Update(avg={updateMs}ms):\n\n{GetDebugText(_updateData)}";
            
            // Debug.Log(text);
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
            _updates = 0;
            _fixeds = 0;
        }

        public void EndFixed()
        {
            _fixeds++;
        }

        public void EndUpdate()
        {
            _updates++;
        }
    }
}