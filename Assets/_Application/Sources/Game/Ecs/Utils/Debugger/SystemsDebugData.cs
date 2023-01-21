using System.Collections.Generic;

namespace Sources.Game.Ecs.Utils.Debugger
{
    public class SystemsDebugData
    {
        public List<SystemsGroupDebugData> FixedDatas { get; }= new();
        public SystemsGroupDebugData UpdateData { get; }= new();
        private int _fixedIndex;

        public void IncreaseFixedIndex() =>
            _fixedIndex++;

        public void AddFixedData(SystemDebugData data)
        {
            while (FixedDatas.Count <= _fixedIndex)
                FixedDatas.Add(new SystemsGroupDebugData());
            
            FixedDatas[_fixedIndex].SystemsData.Add(data);
        }

        public void AddUpdateData(SystemDebugData data) => 
            UpdateData.SystemsData.Add(data);
    }
}