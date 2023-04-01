using Sources.Services.Di;
using UnityEngine;

namespace Sources.App.Game.InputServices
{
    public interface IPlayerInputService : IService
    {
        Vector2 MoveInput { get; }
    }
}