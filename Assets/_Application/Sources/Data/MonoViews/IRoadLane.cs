using Sources.Data.MonoViews;

namespace Sources.Data
{
    public interface IRoadLane
    {
        IRoadLaneCheckpoint Source { get; }
        IRoadLaneCheckpoint Target { get; }
    }
}