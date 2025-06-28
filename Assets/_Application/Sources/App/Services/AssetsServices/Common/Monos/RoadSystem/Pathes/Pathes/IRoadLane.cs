namespace Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Pathes
{
    public interface IRoadLane
    {
        IRoadLaneCheckpoint Source { get; }
        IRoadLaneCheckpoint Target { get; }
    }
}