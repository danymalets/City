namespace Sources.Data.Pathes
{
    public interface IRoadLane
    {
        IRoadLaneCheckpoint Source { get; }
        IRoadLaneCheckpoint Target { get; }
    }
}