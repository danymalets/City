using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Core.Services
{
    public interface IPlayerInputService : IService
    {
        Vector2 MoveInput { get; }
    }
}