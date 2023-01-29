using Sources.Infrastructure.Services;
using UnityEngine;

namespace Sources.Game.InputServices
{
    public interface IPlayerInputService : IService
    {
        Vector2 MoveInput { get; }
    }
}