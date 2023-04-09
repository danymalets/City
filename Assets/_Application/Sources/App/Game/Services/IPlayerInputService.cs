using Sources.Services.Di;
using UnityEngine;

namespace Sources.App.Game.Services
{
    public interface IPlayerInputService : IService
    {
        Vector2 MoveInput { get; }
    }
}