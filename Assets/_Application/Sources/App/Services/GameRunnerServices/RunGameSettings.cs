namespace Sources.App.Services.GameRunnerServices
{
    public struct RunGameSettings
    {
        public bool IsLocal { get; }

        public RunGameSettings(bool isLocal)
        {
            IsLocal = isLocal;
        }
    }
}