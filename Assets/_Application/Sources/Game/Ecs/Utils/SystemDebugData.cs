namespace Sources.Game.Ecs.Utils.Debugger
{
    public class SystemDebugData
    {
        public string Name { get; }
        public long Ticks { get; }

        public SystemDebugData(string name, long ticks)
        {
            Name = name;
            Ticks = ticks;
        }
    }
}