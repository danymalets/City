namespace Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes
{
    public interface IRoadLane
    {
        IRoadLaneCheckpoint Source { get; }
        IRoadLaneCheckpoint Target { get; }
    }
}