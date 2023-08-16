using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Services.UiServices.WindowBase.Screens;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.Input
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