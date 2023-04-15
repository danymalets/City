using _Application.Sources.Utils.Di;
using UnityEngine;

namespace _Application.Sources.App.Core.Services
{
    public interface IPlayerInputService : IService
    {
        Vector2 MoveInput { get; }
    }
}