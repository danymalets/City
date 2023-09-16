using UnityEngine;

namespace Sources.App.Core.Services.Input
{
    public class GameplayInputData
    {
        public Vector2 CarMoveDirection { get; set; }
        public Vector2 PlayerMoveDirection { get; set; }
        public bool WasCarEnterButtonClicked { get; set; }
        public bool WasCarExitButtonClicked { get; set; }
    }
}