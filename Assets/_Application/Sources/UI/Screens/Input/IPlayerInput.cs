using System;
using UnityEngine;

namespace Sources.UI.Screens.Input
{
    public interface IPlayerInput
    {
        event Action<Vector2> Checking;
        event Action StartChecking;
        event Action<Vector2> Selected;
        event Action ForceDisabled;
    }
}