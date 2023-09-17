using Sources.Services.UiServices.WindowBase.Screens;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.PlayerInputScreens
{
    public class PlayerInputScreen : GameScreen
    {
        [FormerlySerializedAs("_joystick")]
        [field: SerializeField]

        public Joystick Joystick;

        [FormerlySerializedAs("_enterCarButton")]
        [field: SerializeField]
        public Button EnterCarButton;
    }
}