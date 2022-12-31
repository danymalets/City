using System;

namespace Sources.Infrastructure.Services.ApplicationCycle
{
    public interface IApplicationCycleService : IService
    {
        event Action BackButtonClicked;
        event Action<bool> FocusStatusChanged;
        event Action<bool> PauseStatusChanged;
        event Action ApplicationQuit;
    }
}