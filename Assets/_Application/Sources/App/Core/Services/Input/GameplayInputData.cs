using UnityEngine;

namespace Sources.App.Core.Services.Input
{
    public class GameplayInputData
    {
        public Vector2 PlayerMoveDirection { get; set; }
        public bool WasJumpPressed { get; set; }
    }
}