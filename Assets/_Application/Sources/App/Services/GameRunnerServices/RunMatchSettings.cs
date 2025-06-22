namespace Sources.App.Services.GameRunnerServices
{
    public struct RunMatchSettings
    {
        public bool IsLocal { get; }

        public RunMatchSettings(bool isLocal)
        {
            IsLocal = isLocal;
        }
    }
}