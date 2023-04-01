using Sources.App.Infrastructure.Services;
using UnityEngine;

namespace Sources.App.Game.InputServices
{
    public interface IPlayerInputService : IService
    {
        Vector2 MoveInput { get; }
    }
}